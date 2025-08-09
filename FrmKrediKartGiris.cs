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
    public partial class FrmKrediKartGiris : Form
    {
        public FrmKrediKartGiris()
        {
            InitializeComponent();
        }

        private void FrmKrediKartGiris_Load(object sender, EventArgs e)
        {
            using (var db = new BudgetContext())
            {
                cmbBanka.DataSource = db.Bankalar.OrderBy(b => b.BankaAdi).ToList();
                cmbBanka.DisplayMember = "BankaAdi";
                cmbBanka.ValueMember = "Id";
                cmbBanka.SelectedIndex = -1;


                cmbSahip.DataSource = db.Kisiler.OrderBy(k => k.Ad).ToList();
                cmbSahip.DisplayMember = "Ad";
                cmbSahip.ValueMember = "Id";
                cmbSahip.SelectedIndex = -1;
            }

            nudKesimGunu.Minimum = 1;
            nudKesimGunu.Maximum = 31;
            nudKesimGunu.Value = 1;

            nudSonOdemeGunu.Minimum = 1;
            nudSonOdemeGunu.Maximum = 31;
            nudSonOdemeGunu.Value = 1;

            KartlariYukle();
        }
        private void KartlariYukle()
        {
            using (var db = new BudgetContext())
            {
                var kartlar = db.Kartlar
                    .Include(k => k.Banka)
                    .Include(k => k.Sahip)
                    .Select(k => new
                    {
                        k.Id,
                        k.KartAdi,
                        BankaAdi = k.Banka.BankaAdi,
                        SahipAdi = k.Sahip.Ad,
                        k.KesimGunu,
                        k.SonOdemeGunu
                    })
                    .OrderBy(k => k.KartAdi)
                    .ToList();

                dgvKartlar.DataSource = kartlar;
                dgvKartlar.Columns["Id"].Visible = false;
                dgvKartlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKartAdi.Text))
            {
                MessageBox.Show("Lütfen kart adı girin.");
                return;
            }

            using (var db = new BudgetContext())
            {
                var kart = new Kart
                {
                    KartAdi = txtKartAdi.Text.Trim(),
                    BankaId = (int)cmbBanka.SelectedValue,
                    SahipId = (int)cmbSahip.SelectedValue,
                    KesimGunu = (int)nudKesimGunu.Value,
                    SonOdemeGunu = (int)nudSonOdemeGunu.Value
                };

                db.Kartlar.Add(kart);
                db.SaveChanges();
            }

            txtKartAdi.Clear();
            KartlariYukle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvKartlar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.");
                return;
            }

            int seciliId = (int)dgvKartlar.CurrentRow.Cells["Id"].Value;

            using (var db = new BudgetContext())
            {
                var kart = db.Kartlar.FirstOrDefault(k => k.Id == seciliId);
                if (kart != null)
                {
                    db.Kartlar.Remove(kart);
                    db.SaveChanges();
                }
            }

            KartlariYukle();
        }

    }
}
