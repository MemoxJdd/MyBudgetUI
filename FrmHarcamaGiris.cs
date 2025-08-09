using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Budget.Entities;

using Microsoft.EntityFrameworkCore;

namespace MyBudgetUI
{
    public partial class FrmHarcamaGiris : Form
    {
        private int? _harcamaId;

        public FrmHarcamaGiris()
        {
            InitializeComponent();
        }

        public FrmHarcamaGiris(Harcama harcama) : this()
        {
            _harcamaId = harcama.Id;
            cmbKisi.SelectedValue = harcama.KisiId;
            cmbKart.SelectedValue = harcama.KartId;
            dtpTarih.Value = harcama.Tarih;
            txtTutar.Text = harcama.Tutar.ToString("0.##");
            txtAciklama.Text = harcama.Aciklama;
            nudTaksitSayisi.Value = harcama.TaksitSayisi;
            chkOrtakMi.Checked = harcama.OrtakMi;
        }

        private void FrmHarcamaGiris_Load(object sender, EventArgs e)
        {
            using (var db = new BudgetContext())
            {
                cmbKategori.DataSource = db.Kategoriler.OrderBy(k => k.Ad).ToList();
                cmbKategori.DisplayMember = "Ad";
                cmbKategori.ValueMember = "Id";
                cmbKategori.SelectedIndex = -1;

                cmbKisi.DataSource = db.Kisiler.ToList();
                cmbKisi.DisplayMember = "Ad";
                cmbKisi.ValueMember = "Id";

                cmbKart.DataSource = db.Kartlar.ToList();
                cmbKart.DisplayMember = "KartAdi";
                cmbKart.ValueMember = "Id";

                if (_harcamaId.HasValue)
                {
                    var harcama = db.Harcamalar.FirstOrDefault(h => h.Id == _harcamaId.Value);
                    if (harcama != null)
                    {
                        cmbKisi.SelectedValue = harcama.KisiId;
                        cmbKart.SelectedValue = harcama.KartId;
                        dtpTarih.Value = harcama.Tarih;
                        txtTutar.Text = harcama.Tutar.ToString("N2");
                        txtAciklama.Text = harcama.Aciklama;
                        nudTaksitSayisi.Value = harcama.TaksitSayisi;
                        chkOrtakMi.Checked = harcama.OrtakMi;
                        cmbKategori.SelectedValue = harcama.KategoriId ?? -1;
                    }
                    else
                    {
                        MessageBox.Show("Düzenlenecek harcama bulunamadı.");
                    }
                }
                else
                {
                    dtpTarih.Value = DateTime.Today;
                    nudTaksitSayisi.Minimum = 1;
                    nudTaksitSayisi.Value = 1;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    Harcama harcama;

                    if (_harcamaId.HasValue)
                    {
                        harcama = db.Harcamalar
                            .Include(h => h.Taksitler)
                            .FirstOrDefault(h => h.Id == _harcamaId.Value);

                        if (harcama == null)
                        {
                            MessageBox.Show("Güncellenecek harcama bulunamadı.");
                            return;
                        }

                        db.Taksitler.RemoveRange(harcama.Taksitler);
                    }
                    else
                    {
                        harcama = new Harcama();
                        db.Harcamalar.Add(harcama);
                    }

                    harcama.KartId = Convert.ToInt32(cmbKart.SelectedValue);
                    harcama.KisiId = Convert.ToInt32(cmbKisi.SelectedValue);
                    harcama.Tarih = dtpTarih.Value;
                    harcama.Tutar = decimal.TryParse(txtTutar.Text, out decimal tutar) ? tutar : 0;
                    harcama.Aciklama = txtAciklama.Text;
                    harcama.TaksitSayisi = (int)nudTaksitSayisi.Value;
                    harcama.OrtakMi = chkOrtakMi.Checked;
                    harcama.KategoriId = cmbKategori.SelectedValue != null ? Convert.ToInt32(cmbKategori.SelectedValue) : (int?)null;

                    db.SaveChanges();
                    

                    // TAKSİT HESAPLAMA
                    var kart = db.Kartlar.FirstOrDefault(k => k.Id == harcama.KartId);
                    int kesimGunu = kart?.KesimGunu ?? 12;

                    DateTime ilkTaksitTarihi = harcama.Tarih.Day <= kesimGunu
                        ? new DateTime(harcama.Tarih.Year, harcama.Tarih.Month, 1)
                        : new DateTime(harcama.Tarih.Year, harcama.Tarih.Month, 1).AddMonths(1);

                    int taksitSayisi = harcama.TaksitSayisi;
                    decimal toplamTutar = harcama.Tutar;
                    decimal taksitTutari = Math.Round(toplamTutar / taksitSayisi, 2);

                    if (harcama.OrtakMi)
                    {
                        var ortaklar = db.Kisiler.Where(k => k.Rol == "ortak").ToList();
                        int ortakSayisi = ortaklar.Count;

                        if (ortakSayisi == 0)
                        {
                            MessageBox.Show("Ortak rolünde tanımlı kişi bulunamadı.");
                            return;
                        }

                        decimal kisiBasiTaksit = Math.Round(taksitTutari / ortakSayisi, 2);

                        for (int i = 0; i < taksitSayisi; i++)
                        {
                            foreach (var kisi in ortaklar)
                            {
                                db.Taksitler.Add(new Taksit
                                {
                                    HarcamaId = harcama.Id,
                                    KisiId = kisi.Id,
                                    Tarih = harcama.Tarih,
                                    Ay = ilkTaksitTarihi.AddMonths(i).ToString("yyyy-MM"),
                                    TaksitNo = i + 1,
                                    Tutar = kisiBasiTaksit
                                });
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < taksitSayisi; i++)
                        {
                            db.Taksitler.Add(new Taksit
                            {
                                HarcamaId = harcama.Id,
                                KisiId = harcama.KisiId,
                                Tarih = harcama.Tarih,
                                Ay = ilkTaksitTarihi.AddMonths(i).ToString("yyyy-MM"),
                                TaksitNo = i + 1,
                                Tutar = taksitTutari
                            });
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show("Harcama başarıyla kaydedildi.");
                   

                    // Kaydetme başarılıysa, formu temizle
                    cmbKart.SelectedIndex = -1;
                    cmbKisi.SelectedIndex = -1;
                    txtAciklama.Text = "";
                    txtTutar.Text = "";
                    nudTaksitSayisi.Value = 1;
                    chkOrtakMi.Checked = false;
                    dtpTarih.Value = DateTime.Now;
                    cmbKategori.SelectedIndex = -1;
                    cmbKisi.Focus();
                    return;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " +ex.ToString()+ ex.Message);
            }
        }
    }
}
