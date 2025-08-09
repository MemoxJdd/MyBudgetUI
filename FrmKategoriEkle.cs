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

namespace MyBudgetUI
{
    public partial class FrmKategoriEkle : Form
    {
        public FrmKategoriEkle()
        {
            InitializeComponent();
        }

        private void FrmKategoriEkle_Load(object sender, EventArgs e)
        {
            KategorileriYukle();
        }

        private void KategorileriYukle()
        {
            using (var db = new BudgetContext())
            {
                var kategoriler = db.Kategoriler
                    .Select(k => new { k.Id, k.Ad })
                    .OrderBy(k => k.Ad)
                    .ToList();

                dgvKategoriler.DataSource = kategoriler;
                dgvKategoriler.Columns["Id"].Visible = false;
                dgvKategoriler.Columns["Ad"].HeaderText = "Kategori";
                dgvKategoriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();

            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Kategori adı boş olamaz.");
                return;
            }

            using (var db = new BudgetContext())
            {
                bool zatenVar = db.Kategoriler.Any(k => k.Ad.ToLower() == ad.ToLower());
                if (zatenVar)
                {
                    MessageBox.Show("Bu isimde bir kategori zaten mevcut.");
                    return;
                }

                var kategori = new Kategori { Ad = ad };
                db.Kategoriler.Add(kategori);
                db.SaveChanges();
            }

            txtAd.Clear();
            KategorileriYukle();
            MessageBox.Show("Kategori başarıyla eklendi.");
        }

    }
}
