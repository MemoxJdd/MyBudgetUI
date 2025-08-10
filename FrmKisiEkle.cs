using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmKisiEkle : Form
    {
        private bool _suppressSelectionChanged = false;

        public FrmKisiEkle()
        {
            InitializeComponent();
            
        }

        private void FrmKisiEkle_Load(object sender, EventArgs e)
        {
            txtAd.Clear();
            cmbRol.SelectedIndex = -1; // Seçili öğeyi kaldırır, boş görünü
            // Rol listesi
            cmbRol.DataSource = new List<string> { "baba", "anne", "çocuk", "ortak", "Ticari" };
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.SelectedIndex = -1;

            dgvKisiler.AutoGenerateColumns = false;
            dgvKisiler.MultiSelect = false;
            dgvKisiler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _suppressSelectionChanged = true;
            Listele();
            TemizleFormVeSecimi();
            _suppressSelectionChanged = false;
        }

        private void Listele()
        {
            using (var db = new BudgetContext())
            {
                var data = db.Kisiler
                             .OrderBy(k => k.Ad)
                             .Select(k => new { k.Id, k.Ad, k.Rol })
                             .ToList();

                dgvKisiler.DataSource = data;
            }
        }

        private void TemizleFormVeSecimi()
        {
            // Seçimi gerçekten sıfırla
            dgvKisiler.ClearSelection();
            dgvKisiler.CurrentCell = null;

            // Alanları temizle
            txtAd.Clear();
            cmbRol.SelectedIndex = -1;

            // Buton durumları
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;

            txtAd.Focus();
        }

        private int? SeciliId()
        {
            if (dgvKisiler.CurrentRow == null) return null;
            var cellVal = dgvKisiler.CurrentRow.Cells["colId"].Value;
            return cellVal != null && int.TryParse(cellVal.ToString(), out int id) ? id : (int?)null;
        }

        private void dgvKisiler_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged) return;
            if (dgvKisiler.CurrentRow == null || !dgvKisiler.CurrentRow.Selected)
            {
                return;
            }

            // Griddeki değerlerden oku (DB’ye tekrar gitmeye gerek yok)
            var id = SeciliId();
            if (id == null) { return; }

            var ad = dgvKisiler.CurrentRow.Cells["colAd"].Value?.ToString() ?? "";
            var rol = dgvKisiler.CurrentRow.Cells["colRol"].Value?.ToString() ?? "";

            txtAd.Text = ad;

            // Rol listesinde yoksa ekle (nadir durum)
            if (!string.IsNullOrWhiteSpace(rol) &&
                !cmbRol.Items.Cast<string>().Any(r => r.Equals(rol, StringComparison.OrdinalIgnoreCase)))
            {
                cmbRol.Items.Add(rol);
            }
            cmbRol.SelectedItem = rol;

            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            _suppressSelectionChanged = true;
            TemizleFormVeSecimi();
            _suppressSelectionChanged = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var ad = txtAd.Text.Trim();
            var rol = cmbRol.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Lütfen hem ad hem rol giriniz.");
                return;
            }

            using (var db = new BudgetContext())
            {
                db.Kisiler.Add(new Kisi { Ad = ad, Rol = rol });
                db.SaveChanges();
            }

            _suppressSelectionChanged = true;
            Listele();
            TemizleFormVeSecimi();
            _suppressSelectionChanged = false;

            MessageBox.Show("Kişi eklendi.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var id = SeciliId();
            if (id == null) { MessageBox.Show("Lütfen listeden kişi seçin."); return; }

            var ad = txtAd.Text.Trim();
            var rol = cmbRol.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Lütfen hem ad hem rol giriniz.");
                return;
            }

            using (var db = new BudgetContext())
            {
                var kisi = db.Kisiler.FirstOrDefault(k => k.Id == id);
                if (kisi == null) { MessageBox.Show("Kayıt bulunamadı."); return; }

                kisi.Ad = ad;
                kisi.Rol = rol;
                db.SaveChanges();
            }

            _suppressSelectionChanged = true;
            Listele();
            TemizleFormVeSecimi();
            _suppressSelectionChanged = false;

            MessageBox.Show("Kişi güncellendi.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var id = SeciliId();
            if (id == null) { MessageBox.Show("Lütfen listeden kişi seçin."); return; }

            if (MessageBox.Show("Seçili kişiyi silmek istiyor musunuz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (var db = new BudgetContext())
                {
                    var kisi = db.Kisiler.FirstOrDefault(k => k.Id == id);
                    if (kisi == null) { MessageBox.Show("Kayıt bulunamadı."); return; }

                    db.Kisiler.Remove(kisi);
                    db.SaveChanges();
                }

                _suppressSelectionChanged = true;
                Listele();
                TemizleFormVeSecimi();
                _suppressSelectionChanged = false;

                MessageBox.Show("Kişi silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme yapılamadı. Bu kişi ile ilişkili kayıtlar olabilir.\n\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
