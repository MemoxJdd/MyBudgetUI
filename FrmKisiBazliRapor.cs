using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Budget;
using Budget.Entities;

using Microsoft.EntityFrameworkCore;
namespace MyBudgetUI
{
    public partial class FrmKisiBazliRapor : Form
    {
        private BudgetContext _context;

        public FrmKisiBazliRapor()
        {
            InitializeComponent();
            _context = new BudgetContext();
        }
        class KartHarcamasi
        {
            public string KartAdi { get; set; }
            public decimal KisiselTutar { get; set; }
            public decimal OrtakTutar { get; set; }
        }

        private void FrmKisiBazliRapor_Load(object sender, EventArgs e)
        {
            // Kişi ComboBox
            cmbKisi.DisplayMember = "Ad";
            cmbKisi.ValueMember = "Id";
            cmbKisi.DataSource = _context.Kisiler.ToList();
            // 

            // Ay ComboBox (taksitlerden distinct şekilde çekiyoruz)
            var donemler = _context.Taksitler
                .Select(t => t.Ay)
                .Distinct()
                .OrderByDescending(a => a)
                .ToList();
            cmbDonem.DataSource = donemler;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (cmbKisi.SelectedItem == null || cmbDonem.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kişi ve dönem seçin.");
                return;
            }

            int kisiId = (int)cmbKisi.SelectedValue;
            string seciliDonem = cmbDonem.SelectedItem.ToString(); // Örnek: "2025-08"

            using (var db = new BudgetContext())
            {
                var ortakRoller = new[] { "ortak" };
                string kisiRol = db.Kisiler
                    .Where(k => k.Id == kisiId)
                    .Select(k => k.Rol)
                    .FirstOrDefault();

                // Kişisel harcamalara ait taksitleri getir
                var kisiselTaksitler = db.Taksitler
                    .Include(t => t.Harcama)
                    .ThenInclude(h => h.Kart)
                    .Where(t =>
                        t.Ay == seciliDonem &&
                        t.Harcama.KisiId == kisiId &&
                        !t.Harcama.OrtakMi)
                    .Select(t => new KartHarcamasi
                    {
                        KartAdi = t.Harcama.Kart.KartAdi,
                        KisiselTutar = t.Tutar,
                        OrtakTutar = 0
                    })
                    .ToList(); // ❗ EF'den belleğe çek

                // Ortak harcamalara ait taksitleri getir (sadece "ortak" rolündeyse)
                var ortakTaksitler = new List<KartHarcamasi>();

                if (ortakRoller.Contains(kisiRol?.ToLower()))
                {
                    ortakTaksitler = db.Taksitler
                        .Include(t => t.Harcama)
                        .ThenInclude(h => h.Kart)
                        .Where(t =>
                            t.Ay == seciliDonem &&
                            t.Harcama.OrtakMi &&
                            t.KisiId == kisiId)
                        .Select(t => new KartHarcamasi
                        {
                            KartAdi = t.Harcama.Kart.KartAdi,
                            KisiselTutar = 0,
                            OrtakTutar = t.Tutar
                        })
                        .ToList(); // ❗ EF'den belleğe çek
                }

                // Gruplama ve toplama işlemi bellekte yapılır
                var sonuc = kisiselTaksitler
                    .Concat(ortakTaksitler)
                    .GroupBy(x => x.KartAdi)
                    .Select(g => new
                    {
                        KartAdi = g.Key,
                        KisiselTutar = Math.Round(g.Sum(x => x.KisiselTutar), 2),
                        OrtakTutar = Math.Round(g.Sum(x => x.OrtakTutar), 2),
                        Toplam = Math.Round(g.Sum(x => x.KisiselTutar + x.OrtakTutar), 2)
                    })
                    .OrderBy(x => x.KartAdi)
                    .ToList();

                // Sonuçları tabloya aktar
                dgvKartOzet.AutoGenerateColumns = true;
                dgvKartOzet.DataSource = sonuc;
                dgvKartOzet.Columns["KisiselTutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvKartOzet.Columns["KisiselTutar"].DefaultCellStyle.Format = "C2";

                dgvKartOzet.Columns["OrtakTutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvKartOzet.Columns["OrtakTutar"].DefaultCellStyle.Format = "C2";
                dgvKartOzet.Columns["Toplam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
               dgvKartOzet.Columns["Toplam"].DefaultCellStyle.Format = "C2";
                dgvKartOzet.Columns["KartAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Toplamı göster
                decimal genelToplam = sonuc.Sum(x => x.Toplam);
                lblToplam.Text = $"Toplam: {genelToplam:C2}";
            }
        }







    }
}

