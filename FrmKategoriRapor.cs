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
using static MyBudgetUI.FrmKategoriGrafik;
using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmKategoriRapor : Form
    {
        public FrmKategoriRapor()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string secilenAy = cmbDonem.Text;
            if (string.IsNullOrWhiteSpace(secilenAy))
            {
                MessageBox.Show("Lütfen bir dönem seçiniz.");
                return;
            }

            using (var db = new BudgetContext())
            {
                var veriler = db.Taksitler
                    .Include(t => t.Harcama)
                    .ThenInclude(h => h.Kategori)
                    .Where(t => t.Ay == secilenAy)
                    .GroupBy(t => t.Harcama.Kategori.Ad)
                    .Select(g => new KategoriRaporDto
                    {
                        Kategori = g.Key ?? "Belirsiz",
                        ToplamTutar = Math.Round(g.Sum(t => t.Tutar), 2)
                    })
                    .OrderBy(x => x.Kategori)
                    .ToList();

                dgvKategoriRapor.DataSource = veriler;
                dgvKategoriRapor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvKategoriRapor.Columns["Kategori"].HeaderText = "Kategori";
                dgvKategoriRapor.Columns["ToplamTutar"].DefaultCellStyle.Format = "C2";
                dgvKategoriRapor.Columns["ToplamTutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                decimal genelToplam = veriler.Sum(x => x.ToplamTutar);
                lblToplam.Text = $"Toplam: {genelToplam:C2}";
            }
        }

        private void FrmKategoriRapor_Load(object sender, EventArgs e)
        {
            using (var db = new BudgetContext())
            {
                var donemler = db.Taksitler
                    .Select(t => t.Ay)
                    .Distinct()
                    .OrderByDescending(d => d)
                    .ToList();

                cmbDonem.DataSource = donemler;
            }
        }

        private void btnGrafikGoster_Click(object sender, EventArgs e)
        {
            if (dgvKategoriRapor.DataSource == null || dgvKategoriRapor.Rows.Count == 0)
            {
                MessageBox.Show("Lütfen önce raporu listeleyin.");
                return;
            }
            var veriler = dgvKategoriRapor.DataSource as List<KategoriRaporDto>;
            if (veriler == null || veriler.Count == 0)
            {
                MessageBox.Show("Grafik için yeterli veri yok.");
                return;
            }
            string secilenDonem = cmbDonem.Text;
            FrmKategoriGrafik frmGrafik = new FrmKategoriGrafik(veriler, secilenDonem);
            frmGrafik.Show();

        }



    }
}
