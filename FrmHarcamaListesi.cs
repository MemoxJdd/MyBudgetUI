using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Budget.Entities;

using Microsoft.EntityFrameworkCore;

namespace MyBudgetUI
{
    public partial class FrmHarcamaListesi : Form
    {
        private BudgetContext _context;
       // private int seciliHarcamaId = -1;
        private int seciliKisiId = -1;
        private int seciliTaksitId = -1;
        private int? _harcamaId = null;
        public FrmHarcamaListesi()
        {
            InitializeComponent();
            _context = new BudgetContext();
        }

        private void FrmHarcamaListesi_Load(object sender, EventArgs e)
        {
            dgvHarcamalar.AutoGenerateColumns = true;
            ListeleHarcamalar();
        }


        private void ListeleHarcamalar()
        {
            var harcamalar = _context.Harcamalar
                .Include(h => h.Kisi)
                .Include(h => h.Kart)
                .Include(h => h.Kategori)
                .ToList();

            dgvHarcamalar.DataSource = harcamalar.Select(h => new
            {
                h.Id,
                Kisi = h.Kisi.Ad,
                Kart = h.Kart.KartAdi,
                h.Tarih,
                h.Tutar,
                h.OrtakMi,
                Taksit = h.TaksitSayisi > 1 ? $"{h.TaksitSayisi} Taksit" : "Peşin",
                h.Aciklama,
                Kategori = h.Kategori != null ? h.Kategori.Ad : "(Yok)" // <-- Bu satır aktif!
            }).ToList();

            dgvHarcamalar.Columns["Kart"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHarcamalar.Columns["Tarih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHarcamalar.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHarcamalar.Columns["Taksit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // dgvHarcamalar.Columns["Kategori"].DataPropertyName = "Kategori"; // <-- SİL!

            dgvHarcamalar.Columns["Tutar"].DefaultCellStyle.Format = "C2";
            dgvHarcamalar.Columns["Id"].Width = 30;
            dgvHarcamalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvHarcamalar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.");
                return;
            }

            int secilenId = Convert.ToInt32(dgvHarcamalar.CurrentRow.Cells["Id"].Value);

            using (var db = new BudgetContext())
            {
                var harcama = db.Harcamalar.FirstOrDefault(h => h.Id == secilenId);

                if (harcama != null)
                {
                    // İlgili taksitleri sil
                    var taksitler = db.Taksitler.Where(t => t.HarcamaId == harcama.Id).ToList();
                    db.Taksitler.RemoveRange(taksitler);

                    db.Harcamalar.Remove(harcama);
                    db.SaveChanges();
                    MessageBox.Show("Kayıt silindi.");
                    ListeleHarcamalar();
                }
            }
        }

        public void HarcamalariYukle()
        {
            using (var db = new BudgetContext())
            {
                
                var liste = (from h in db.Harcamalar
                             join k in db.Kisiler on h.KisiId equals k.Id
                             join kk in db.Kartlar on h.KartId equals kk.Id
                             join kat in db.Kategoriler on h.KategoriId equals kat.Id into katJoin
                             from kat in katJoin.DefaultIfEmpty()  // KategoriId boşsa da sorun çıkmasın
                             select new
                             {
                                 h.Id,
                                 Kisi = k.Ad,
                                 Kart = kk.KartAdi,
                                 h.Tarih,
                                 h.Tutar,
                                 h.Aciklama,
                                 h.TaksitSayisi,
                                 Ortak = h.OrtakMi ? "Evet" : "Hayır",
                                 Kategori = kat != null ? kat.Ad : "" // Boş kategoriye karşı koruma
                             }).ToList();


                 dgvHarcamalar.DataSource = liste;
                 dgvHarcamalar.Columns["Id"].Width = 30;
                 dgvHarcamalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
               
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvHarcamalar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir kayıt seçin.");
                return;
            }

            int secilenId = Convert.ToInt32(dgvHarcamalar.CurrentRow.Cells["Id"].Value);

            using (var db = new BudgetContext())
            {
                var harcama = db.Harcamalar.FirstOrDefault(h => h.Id == secilenId);
                if (harcama == null)
                {
                    MessageBox.Show("Seçilen harcama bulunamadı.");
                    return;
                }

                var frm = new FrmHarcamaGiris(harcama);  // Constructor üzerinden harcama nesnesi gönderiliyor

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    HarcamalariYukle(); // Listeyi güncelle
                    ListeleHarcamalar();
                }
            }
        }



    }



}
