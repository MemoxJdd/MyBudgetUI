using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Budget;

using Microsoft.EntityFrameworkCore;
using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmKartExtre : Form
    {
        private BudgetContext _context;
        public FrmKartExtre()
        {
            InitializeComponent();
            _context = new BudgetContext();

        }


        private void FrmKartExtre_Load(object sender, EventArgs e)
        {
            using (var db = new BudgetContext())
            {
                cmbKart.DataSource = db.Kartlar.ToList();
                cmbKart.DisplayMember = "KartAdi";
                cmbKart.ValueMember = "Id";


                // Ay ComboBox (taksitlerden distinct şekilde çekiyoruz)
                var donemler = _context.Taksitler
                    .Select(t => t.Ay)
                    .Distinct()
                    .OrderByDescending(a => a)
                    .ToList();
                cmbAy.DataSource = donemler;
                // Dönem listesi için son 12 ay örneği:
                /*  var aylar = Enumerable.Range(0, 12)
                      .Select(i => DateTime.Today.AddMonths(-i).ToString("yyyy-MM"))
                      .ToList();
                  cmbAy.DataSource = aylar;*/
            }

            cmbKart.SelectedIndex = -1;
            cmbAy.SelectedIndex = -1;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var seciliKartId = (int)cmbKart.SelectedValue;
            var seciliYilAy = cmbAy.SelectedItem.ToString();

            using (var db = new BudgetContext())
            {
                // Taksitleri harcama bilgileriyle birlikte çekiyoruz
                var taksitler = db.Taksitler
                    .Include(t => t.Harcama)
                    .Where(t => t.Harcama.KartId == seciliKartId && t.Ay == seciliYilAy)
                    .ToList();  // ❗ Veritabanından çekip belleğe alıyoruz

                // Bellek üzerinde grupluyoruz
                var liste = taksitler
                    .GroupBy(t => new
                    {
                        t.HarcamaId,
                        t.TaksitNo,
                        t.Tarih,
                        t.Harcama.Aciklama,
                        t.Harcama.OrtakMi
                    })
                    .Select(g => new
                    {
                        Tarih = g.Key.Tarih.ToShortDateString(),
                        Aciklama = g.Key.Aciklama,
                        OrtakMi = g.Key.OrtakMi ? "Evet" : "Hayır",
                        TaksitNo = g.Key.TaksitNo,
                        Tutar = g.Sum(x => x.Tutar)
                    })
                    .OrderBy(x => x.Tarih)
                    .ToList();

                dgvExtre.DataSource = liste;
                dgvExtre.Columns["Aciklama"].Width = 150;


                dgvExtre.Columns["Tarih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvExtre.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvExtre.Columns["TaksitNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvExtre.Columns["Tutar"].DefaultCellStyle.Format = "C2";



                // Toplam tutarı göster
                decimal toplam = liste.Sum(x => x.Tutar);

                if (lblToplam != null)
                {
                    lblToplam.Text = $"Toplam: {toplam:C2}";
                }


            }
        }




        private void FrmKartExtre_FormClosing(object sender, FormClosingEventArgs e)
        {
            // db?.Dispose();
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            if (dgvExtre.Rows.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri bulunamadı.");
                return;
            }

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Kart Ekstresi");

                // Başlıkları yaz
                for (int i = 0; i < dgvExtre.Columns.Count; i++)
                {
                    ws.Cell(1, i + 1).Value = dgvExtre.Columns[i].HeaderText;
                    ws.Cell(1, i + 1).Style.Font.Bold = true;
                    ws.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // Veri yazımı
                for (int row = 0; row < dgvExtre.Rows.Count; row++)
                {
                    for (int col = 0; col < dgvExtre.Columns.Count; col++)
                    {
                        var value = dgvExtre.Rows[row].Cells[col].Value;
                        var cell = ws.Cell(row + 2, col + 1);
                        string columnName = dgvExtre.Columns[col].HeaderText.ToLower();

                        if (value == null)
                        {
                            cell.Value = "";
                            continue;
                        }

                        // Sadece "tutar" içeren sütunlara para formatı uygula
                        if ((columnName.Contains("tutar") || columnName.Contains("toplam")) &&
                            decimal.TryParse(value.ToString(), out decimal money))
                        {
                            cell.Value = money;
                            cell.Style.NumberFormat.Format = "#,##0.00 ₺";
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                        else
                        {
                            cell.Value = value.ToString();

                            // Sayı değilse ortala, tarihse sola yasla
                            if (DateTime.TryParse(value.ToString(), out _))
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            else
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        if (DateTime.TryParse(value.ToString(), out _) || columnName.Contains("tarih"))
                        {
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                        else
                        {
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                    }
                }

                ws.Columns().AdjustToContents();

                var dialog = new SaveFileDialog
                {
                    Filter = "Excel Dosyası (*.xlsx)|*.xlsx",
                    FileName = $"KartEkstresi_{DateTime.Now:yyyyMMdd}.xlsx"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        wb.SaveAs(dialog.FileName);
                        MessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya oluşturulurken hata oluştu: " + ex.Message);
                    }
                }
            }
        }
    }

}

