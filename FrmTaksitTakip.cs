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
using Budget;
using Budget.Dto;
using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmTaksitTakip : Form
    {
        public FrmTaksitTakip()
        {
            InitializeComponent();
            //cmbKisiler.SelectedIndex = -1;
        }

        private void FrmTaksitTakip_Load(object sender, EventArgs e)

        {
           // dgvTaksitDurum.AutoGenerateColumns = false;            
          

            using (var db = new BudgetContext())
    {
                var kisiler = db.Kisiler
                    .Select(k => new { k.Id, k.Ad })
                    .ToList();

                cmbKisiler.DataSource = kisiler;
                cmbKisiler.DisplayMember = "Ad";
                cmbKisiler.ValueMember = "Id";
            }


            using (var db = new BudgetContext())
            {
                var taksitler = db.Taksitler
                    .Include(t => t.Harcama)
                    .ThenInclude(h => h.Kisi)
                    .Include(t => t.Harcama.Kart)
                    .ToList();

                var odemeler = db.Odemeler.ToList();

                var taksitDurumListesi = taksitler.Select(t =>
                {
                    string donem = t.Ay;
                    int kisiId = t.Harcama.KisiId;

                    // Bu kişi bu dönemde toplam ne kadar ödeme yapmış?
                    decimal toplamOdeme = odemeler
                        .Where(o => o.KisiId == kisiId && o.Donem == donem)
                        .Sum(o => o.Tutar);

                    bool odendiMi = toplamOdeme >= t.Tutar;

                    return new TaksitDurumDto
                    {
                        Kisi = t.Harcama.Kisi.Ad,
                        Kart = t.Harcama.Kart.KartAdi,
                        Harcama = t.Harcama.Aciklama,
                        Ay = donem,
                       TaksitNo=t.TaksitNo,                        
                        Tutar = t.Tutar,
                        OdendiMi = odendiMi
                    };
                })
                .OrderBy(x => x.Kisi)
                .ThenBy(x => x.Ay)
                .ThenBy(x => x.TaksitNo)
                .ToList();

                dgvTaksitDurum.DataSource = taksitDurumListesi;

                // Görsel düzenlemeler
                dgvTaksitDurum.Columns["Tutar"].DefaultCellStyle.Format = "C2";
                dgvTaksitDurum.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTaksitDurum.Columns["OdendiMi"].HeaderText = "Ödendi mi?";
                dgvTaksitDurum.Columns["OdendiMi"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                dgvTaksitDurum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (cmbKisiler.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir kişi seçin.");
                return;
            }

            int secilenKisiId;
            if (!int.TryParse(cmbKisiler.SelectedValue.ToString(), out secilenKisiId))
            {
                MessageBox.Show("Kişi seçimi geçersiz.");
                return;
            }

            using (var db = new BudgetContext())
            {
                // Taksit ve ilişkili tablolar
                var taksitler = db.Taksitler
                    .Include(t => t.Harcama)
                        .ThenInclude(h => h.Kart)
                    .Include(t => t.Harcama.Kisi)
                    .ToList();

                var odemeler = db.Odemeler.ToList();

                // DTO listesi
                var dtoList = taksitler
                    .Where(t => t.Harcama != null && t.Harcama.KisiId == secilenKisiId)
                    .Select(t => new TaksitOdemeDurumuDto
                    {
                       // TaksitId = t.Id,
                        KisiAdi = t.Harcama.Kisi != null ? t.Harcama.Kisi.Ad : "(Bilinmiyor)",
                        KartAdi = t.Harcama.Kart != null ? t.Harcama.Kart.KartAdi : "(Kart Yok)",
                        Tarih = t.Harcama.Tarih,
                        Ay = t.Ay,
                        Tutar = t.Tutar,
                        TaksitNo = t.TaksitNo,
                        Aciklama = t.Harcama.Aciklama,
                        OdendiMi = odemeler.Any(o =>
                            o.KisiId == t.Harcama.KisiId &&
                            Math.Abs(o.Tutar - t.Tutar) < 0.01m &&
                            o.Tarih.ToString("yyyy-MM") == t.Ay)
                    })
                    .ToList();

                // Grid'e aktar
                dgvTaksitDurum.DataSource = dtoList;

                // Sütun kontrolleri ve biçimlendirme
                if (dgvTaksitDurum.Columns.Contains("Tutar"))
                {
                    dgvTaksitDurum.Columns["Tutar"].DefaultCellStyle.Format = "C2";
                    dgvTaksitDurum.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvTaksitDurum.Columns.Contains("TaksitNo"))
                {
                    dgvTaksitDurum.Columns["TaksitNo"].HeaderText = "Taksit No";
                    dgvTaksitDurum.Columns["TaksitNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvTaksitDurum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

                // Renk kontrolü
                foreach (DataGridViewRow row in dgvTaksitDurum.Rows)
                {
                    if (row.Cells["OdendiMi"].Value is bool odendi && !odendi)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }


    }
}
