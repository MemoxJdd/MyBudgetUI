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
using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmOdemeListesi : Form

    {
        public FrmOdemeListesi()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var baslangic = dtpBaslangic.Value.Date;
                    var bitis = dtpBitis.Value.Date.AddDays(1); // Gün sonuna kadar dahil

                    var liste = db.Odemeler
                        .Include(o => o.Kisi)
                        .Where(o => o.Tarih >= baslangic && o.Tarih < bitis)
                        .OrderBy(o => o.Tarih)
                        .Select(o => new
                        {
                            o.Id,
                            Kisi = o.Kisi.Ad,
                            o.Tarih,
                            o.Aciklama,
                            o.Tutar
                           
                           
                        })
                        .ToList();

                    dgvListe.DataSource = liste;
                    dgvListe.Columns[0].Visible = false; // ID gizle
                    dgvListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                   
                    dgvListe.Columns["Tarih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvListe.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvListe.Columns["Tutar"].DefaultCellStyle.Format = "C2";
                    dgvListe.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    decimal toplam = liste.Sum(x => x.Tutar);
                    lblToplam.Text = $"Toplam: {toplam:N2} ₺";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme sırasında hata oluştu: " + ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvListe.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek satırı seçin.");
                return;
            }

            int id = (int)dgvListe.CurrentRow.Cells["Id"].Value;
            var frm = new FrmOdemeGiris(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Listele();
            }
        }
        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {
            Listele();
        }
       

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvListe.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek satırı seçin.");
                return;
            }

            var sonuc = MessageBox.Show("Seçili ödemeyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (sonuc != DialogResult.Yes) return;

            try
            {
                int id = (int)dgvListe.CurrentRow.Cells["Id"].Value;

                using (var db = new BudgetContext())
                {
                    var odeme = db.Odemeler.FirstOrDefault(o => o.Id == id);
                    if (odeme != null)
                    {
                        db.Odemeler.Remove(odeme);
                        db.SaveChanges();
                        Listele();
                        MessageBox.Show("Ödeme silindi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message);
            }
        }

        private void FrmOdemeListesi_Load(object sender, EventArgs e)
        {
            dtpBaslangic.Value = DateTime.Today;
            dtpBitis.Value = DateTime.Today;
        }
    }
}
        
    

