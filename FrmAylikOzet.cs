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
using Microsoft.EntityFrameworkCore;

namespace MyBudgetUI
{
    public partial class FrmAylikOzet : Form
    {
        private Budget.Entities.BudgetContext _context;
        public FrmAylikOzet()
        {
            InitializeComponent();
            _context = new Budget.Entities.BudgetContext();
        }

        private void FrmAylikOzet_Load(object sender, EventArgs e)
        {
            dgvOzet.AutoGenerateColumns = true;

            // Ay ComboBox (taksitlerden distinct şekilde çekiyoruz)
            var donemler = _context.Taksitler
                .Select(t => t.Ay)
                .Distinct()
                .OrderByDescending(a => a)
                .ToList();
            cmbAy.DataSource = donemler;
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            if (cmbAy.SelectedItem == null)
                return;

            string secilenAy = cmbAy.SelectedItem.ToString(); // Örnek: "2025-08"

            using (var db = new Budget.Entities.BudgetContext())
            {
                var kisiler = db.Kisiler.ToList();
                var tumTaksitler = db.Taksitler
                    .Include(t => t.Harcama)
                    .Where(t => t.Ay == secilenAy)
                    .ToList();

                var ozetListe = new List<dynamic>();

                foreach (var kisi in kisiler)
                {
                    decimal kisiselToplam = tumTaksitler
                        .Where(t => t.Harcama.KisiId == kisi.Id && !t.Harcama.OrtakMi)
                        .Sum(t => t.Tutar);

                    decimal ortakPay = 0;

                    if (kisi.Rol?.ToLower() == "ortak")
                    {
                        // Toplam ortak kişi sayısı
                        int ortakKisiSayisi = kisiler.Count(k => k.Rol?.ToLower() == "ortak");

                        if (ortakKisiSayisi > 0)
                        {
                            ortakPay = tumTaksitler
                                .Where(t => t.Harcama.OrtakMi)
                                .Sum(t => t.Tutar / ortakKisiSayisi);
                        }
                    }

                    decimal toplam = kisiselToplam + ortakPay;

                    if (toplam > 0)
                    {
                        ozetListe.Add(new
                        {
                            Kisi = kisi.Ad,
                            Kisisel = kisiselToplam.ToString("C2"),
                            OrtakPayi = ortakPay.ToString("C2"),
                            Toplam = toplam.ToString("C2")
                        });
                    }
                }

                dgvOzet.AutoGenerateColumns = true;
                dgvOzet.DataSource = ozetListe;
                dgvOzet.Columns["Kisisel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOzet.Columns["OrtakPayi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOzet.Columns["Toplam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

    }
}
