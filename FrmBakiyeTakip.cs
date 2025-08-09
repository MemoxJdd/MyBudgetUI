using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Budget.Dto;
using Budget;

using ClosedXML.Excel;

using DocumentFormat.OpenXml.Spreadsheet;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmBakiyeTakip : Form
    {
        private DataGridViewCellEventHandler dgvBakiye_CellDoubleClick;

        public FrmBakiyeTakip()
        {
            InitializeComponent();


        }

        private void FrmBakiyeTakip_Load(object sender, EventArgs e)
        {
          

            dtpAySecimi.Format = DateTimePickerFormat.Custom;
            dtpAySecimi.CustomFormat = "MMMM yyyy";  // Sadece ay ve yıl göster
            dtpAySecimi.Value = DateTime.Today;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                string seciliDonem = dtpAySecimi.Value.ToString("yyyy-MM");

                using (var db = new BudgetContext())
                {
                    var kisiler = db.Kisiler.ToList();

                    var taksitler = db.Taksitler
                        .Where(t => t.Ay == seciliDonem)
                        .GroupBy(t => t.KisiId)
                        .ToDictionary(g => g.Key, g => g.Sum(x => x.Tutar));

                    var odemeler = db.Odemeler
                        .Where(o => o.Donem == seciliDonem)
                        .GroupBy(o => o.KisiId)
                        .ToDictionary(g => g.Key, g => g.Sum(x => x.Tutar));

                    // DTO kullanarak liste oluştur
                    var bakiyeListesi = kisiler.Select(k => new KisiBakiyeDto
                    {
                        KisiId = k.Id,
                        Ad = k.Ad,
                        Harcama = taksitler.ContainsKey(k.Id) ? taksitler[k.Id] : 0,
                        Odeme = odemeler.ContainsKey(k.Id) ? odemeler[k.Id] : 0
                    }).ToList();

                    dgvBakiyeListesi.DataSource = bakiyeListesi;

                    dgvBakiyeListesi.Columns["KisiId"].Visible = false;

                    dgvBakiyeListesi.Columns["Harcama"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvBakiyeListesi.Columns["Odeme"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvBakiyeListesi.Columns["Bakiye"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // Renk: Negatif bakiyeler kırmızı
                    foreach (DataGridViewRow row in dgvBakiyeListesi.Rows)
                    {
                        if (row.Cells["Bakiye"].Value is decimal bakiye && bakiye < 0)
                        {
                            row.Cells["Bakiye"].Style.ForeColor = System.Drawing.Color.Red;
                            row.Cells["Bakiye"].Value = Math.Abs(bakiye); // - işareti göstermeyelim
                        }
                    }

                    // Toplamları göster
                    decimal toplamHarcama = bakiyeListesi.Sum(x => x.Harcama);
                    decimal toplamOdeme = bakiyeListesi.Sum(x => x.Odeme);

                    lblToplam.Text = $"Toplam Harcama: {toplamHarcama:N2} TL  |  Toplam Ödeme: {toplamOdeme:N2} TL";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void dgvListe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var columnName = dgvBakiyeListesi.Columns[e.ColumnIndex].Name;

            if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
            {
                if (columnName == "Bakiye")
                {
                    if (value < 0)
                    {
                        e.CellStyle.ForeColor = System.Drawing.Color.Red;
                        e.Value = string.Format("{0:C2}", Math.Abs(value)); // Negatif işaret kaldırılır
                    }
                    else
                    {
                        e.CellStyle.ForeColor = System.Drawing.Color.Black;
                        e.Value = string.Format("{0:C2}", value);
                    }

                    e.FormattingApplied = true;
                }
                else if (columnName == "Harcama" || columnName == "Odeme")
                {
                    e.Value = string.Format("{0:C2}", value); // Sadece ₺ formatı uygulanır
                    e.FormattingApplied = true;
                }
            }
        }




        private void btnExceleAktar_Click(object sender, EventArgs e)
        {
            if (dgvBakiyeListesi.Rows.Count == 0)
            {
                MessageBox.Show("Önce bir liste oluşturmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Dosyası|*.xlsx",
                FileName = "BakiyeRaporu.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Bakiye Raporu");

                        // Başlıklar
                        for (int i = 0; i < dgvBakiyeListesi.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvBakiyeListesi.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                        }

                        // Satırlar ve biçimlendirme
                        for (int i = 0; i < dgvBakiyeListesi.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvBakiyeListesi.Columns.Count; j++)
                            {
                                var value = dgvBakiyeListesi.Rows[i].Cells[j].Value;

                                var cell = worksheet.Cell(i + 2, j + 1);
                                cell.Value = value?.ToString();
                                dgvBakiyeListesi.Columns["Bakiye"].Name = "Bakiye";

                                // Para birimi biçimi uygula
                                string header = dgvBakiyeListesi.Columns[j].HeaderText.ToLower();
                                if (header.Contains("harcama") || header.Contains("odeme") || header.Contains("bakiye"))
                                {
                                    if (decimal.TryParse(value?.ToString().Replace("₺", "").Trim(), out decimal decimalValue))
                                    {
                                        cell.Value = decimalValue;
                                        cell.Style.NumberFormat.Format = "₺#,##0.00";
                                    }
                                }
                            }
                        }

                        worksheet.Columns().AdjustToContents(); // Otomatik sütun genişliği
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvBakiyeListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var secilenKisi = dgvBakiyeListesi.Rows[e.RowIndex].DataBoundItem as KisiBakiyeDto;
            if (secilenKisi == null)
                return;

            int kisiId = secilenKisi.KisiId;
            string donem = dtpAySecimi.Value.ToString("yyyy-MM");

            var frmDetay = new FrmKisiDetay(kisiId, donem);
            frmDetay.ShowDialog();
        }

       
    }
}
