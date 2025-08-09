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
    public partial class FrmOdemeGiris : Form
    {
        private int? _odemeId = null;

        public FrmOdemeGiris(int id)
        {
            InitializeComponent();
            _odemeId = id;
        }

        public FrmOdemeGiris()
        {
            InitializeComponent();
        }

        private void FrmOdemeGiris_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var kisiler = db.Kisiler
                                    .Select(k => new
                                    {
                                        k.Id,
                                        k.Ad
                                    })
                                    .OrderBy(k => k.Ad)
                                    .ToList();

                    cmbKisi.DataSource = kisiler;
                    cmbKisi.DisplayMember = "Ad";
                    cmbKisi.ValueMember = "Id";
                    cmbKisi.SelectedIndex = -1;

                    if (_odemeId.HasValue)
                    {
                        var odeme = db.Odemeler.FirstOrDefault(o => o.Id == _odemeId.Value);
                        if (odeme != null)
                        {
                            cmbKisi.SelectedValue = odeme.KisiId;
                            txtTutar.Text = odeme.Tutar.ToString("N2");
                            dtpTarih.Value = odeme.Tarih;
                            txtAciklama.Text = odeme.Aciklama;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kişi listesi yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    if (!decimal.TryParse(txtTutar.Text, out decimal tutar))
                    {
                        MessageBox.Show("Lütfen geçerli bir tutar giriniz.");
                        return;
                    }

                    if (cmbKisi.SelectedIndex == -1)
                    {
                        MessageBox.Show("Lütfen bir kişi seçiniz.");
                        return;
                    }
                    // Donem hesapla: tarih hangi ay ise o ayı döneme yaz
                    string donem = dtpTarih.Value.ToString("yyyy-MM");
                    

                    Odeme odeme;

                    if (_odemeId.HasValue)
                    {
                        odeme = db.Odemeler.FirstOrDefault(o => o.Id == _odemeId.Value);
                        if (odeme == null)
                        {
                            MessageBox.Show("Güncellenecek ödeme bulunamadı.");
                            return;
                        }
                    }
                    else
                    {
                        odeme = new Odeme();
                        db.Odemeler.Add(odeme);
                    }
                    
                    odeme.KisiId = (int)cmbKisi.SelectedValue;
                    odeme.Tarih = dtpTarih.Value;
                    odeme.Aciklama = txtAciklama.Text;
                    odeme.Tutar = tutar;
                    odeme.Donem = donem;
                   

                    db.SaveChanges();


                    MessageBox.Show("Ödeme kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbKisi.SelectedIndex = -1;
                    txtTutar.Clear();
                    txtAciklama.Clear();
                    dtpTarih.Value = DateTime.Today;

                    return;

                    if (!_odemeId.HasValue)
                    {
                        cmbKisi.SelectedIndex = -1;
                        txtTutar.Clear();
                        txtAciklama.Clear();
                        dtpTarih.Value = DateTime.Today;
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbKisi.SelectedIndex = -1;
                        txtTutar.Clear();
                        txtAciklama.Clear();
                        dtpTarih.Value = DateTime.Today;
                    }
                }
            }
            catch (Exception ex)
            {
                string detay = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show("Hata oluştu: " + detay, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
    }
}
