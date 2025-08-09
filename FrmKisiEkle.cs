using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmKisiEkle : Form
    {
        private int? _seciliKisiId = null;

        public FrmKisiEkle()
        {
            InitializeComponent();
        }

        private void FrmKisiGiris_Load(object sender, EventArgs e)
        {
            // Roller
            var roller = new List<string> { "baba", "anne", "çocuk", "ortak", "Ticari" };
            cmbRol.DataSource = roller;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.SelectedIndex = -1;

            // Grid
            dgvKisiler.AutoGenerateColumns = true;
            dgvKisiler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKisiler.MultiSelect = false;
            dgvKisiler.ReadOnly = true;
            dgvKisiler.AllowUserToAddRows = false;

            KisileriYukle();
            FormuTemizleVeButonlariAyarlat();
        }

        private void KisileriYukle()
        {
            using (var db = new BudgetContext())
            {
                var kisiler = db.Kisiler
                                .Select(k => new { k.Id, k.Ad, k.Rol })
                                .OrderBy(k => k.Ad)
                                .ToList();

                dgvKisiler.DataSource = kisiler;

                if (dgvKisiler.Columns.Contains("Id"))
                    dgvKisiler.Columns["Id"].Visible = false;

                dgvKisiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void FormuTemizleVeButonlariAyarlat()
        {
            _seciliKisiId = null;
            txtAd.Clear();
            cmbRol.SelectedIndex = -1;

            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnEkle.Enabled = true;

            txtAd.Focus();
        }

        private bool GirdiGecerliMi(out string ad, out string rol)
        {
            ad = txtAd.Text.Trim();
            rol = cmbRol.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show("Lütfen bir ad girin.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Lütfen bir rol seçin.");
                return false;
            }
            return true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirdiGecerliMi(out var ad, out var rol)) return;

            using (var db = new BudgetContext())
            {
                db.Kisiler.Add(new Kisi { Ad = ad, Rol = rol });
                db.SaveChanges();
            }

            KisileriYukle();
            FormuTemizleVeButonlariAyarlat();
            MessageBox.Show("Kişi başarıyla eklendi.");
        }

        private void dgvKisiler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKisiler.CurrentRow == null || dgvKisiler.CurrentRow.DataBoundItem == null)
            {
                FormuTemizleVeButonlariAyarlat();
                return;
            }

            // Selected row değerlerini forma bas
            var row = dgvKisiler.CurrentRow;
            if (!row.DataGridView.Columns.Contains("Id")) return;

            _seciliKisiId = (int)row.Cells["Id"].Value;
            txtAd.Text = row.Cells["Ad"].Value?.ToString() ?? "";
            cmbRol.SelectedItem = row.Cells["Rol"].Value?.ToString();

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnEkle.Enabled = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_seciliKisiId == null)
            {
                MessageBox.Show("Güncellenecek bir kişi seçiniz.");
                return;
            }
            if (!GirdiGecerliMi(out var ad, out var rol)) return;

            using (var db = new BudgetContext())
            {
                var kisi = db.Kisiler.FirstOrDefault(k => k.Id == _seciliKisiId.Value);
                if (kisi == null)
                {
                    MessageBox.Show("Kayıt bulunamadı (başkası silmiş olabilir).");
                    KisileriYukle();
                    FormuTemizleVeButonlariAyarlat();
                    return;
                }

                kisi.Ad = ad;
                kisi.Rol = rol;
                db.SaveChanges();
            }

            KisileriYukle();
            FormuTemizleVeButonlariAyarlat();
            MessageBox.Show("Kişi başarıyla güncellendi.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_seciliKisiId == null)
            {
                MessageBox.Show("Silmek için bir kişi seçiniz.");
                return;
            }

            var onay = MessageBox.Show("Seçili kişiyi silmek istediğinize emin misiniz?",
                                       "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (onay != DialogResult.Yes) return;

            try
            {
                using (var db = new BudgetContext())
                {
                    var kisi = db.Kisiler.FirstOrDefault(k => k.Id == _seciliKisiId.Value);
                    if (kisi == null)
                    {
                        MessageBox.Show("Kayıt bulunamadı (başkası silmiş olabilir).");
                    }
                    else
                    {
                        db.Kisiler.Remove(kisi);
                        db.SaveChanges();
                        MessageBox.Show("Kişi silindi.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Çoğu zaman FK kısıtından yakalanır (Harcama, Ödeme, Taksit vs. ilişki)
                MessageBox.Show("Silme işlemi başarısız. Kişiye ait bağlı kayıtlar olabilir.\n\n" +
                                $"Detay: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            KisileriYukle();
            FormuTemizleVeButonlariAyarlat();
        }
    }
}
