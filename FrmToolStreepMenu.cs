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

namespace MyBudgetUI
{
    public partial class FrmToolStreepMenu : Form
    {
        public FrmToolStreepMenu()
        {
            InitializeComponent();
            // this.Icon = new Icon("wallet.ico");
        }

        private void tsmVeriTemizle_Click(object sender, EventArgs e)
        {

            var onay = MessageBox.Show("Tüm harcamalar ve taksitler silinecek. Emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (onay != DialogResult.Yes)
                return;

            using (var db = new BudgetContext())
            {
                // Önce taksitler silinmeli (yabancı anahtar bağımlılığı nedeniyle)
                db.Taksitler.RemoveRange(db.Taksitler);
                db.Harcamalar.RemoveRange(db.Harcamalar);
                db.SaveChanges();
            }

            MessageBox.Show("Veriler temizlendi.");

        }
        private void tsmOdemeRapor_Click(object? sender, EventArgs e)
        {
            var frm = new FrmOdemeListesi();
            frm.ShowDialog();
        }

        private void tsmOdemeGiris_Click(object sender, EventArgs e)
        {
            var frm = new FrmOdemeGiris();
            frm.ShowDialog(); // modal
        }

        private void tsmHarcamaEkle_Click(object sender, EventArgs e)
        {
            var frm = new FrmHarcamaGiris();
            frm.ShowDialog(); // modal
        }
        private void tsmKategoriRaporu_Click(object sender, EventArgs e)
        {
            var frm = new FrmKategoriRapor();
            frm.ShowDialog(); // modal
        }
        private void tsmKategoriEkle_Click(object sender, EventArgs e)
        {
            var frm = new FrmKategoriEkle();
            frm.ShowDialog(); // modal
        }
        private void tsmAylikRapor_Click(object sender, EventArgs e)
        {
            FrmAylikOzet frm = new FrmAylikOzet(); // formun gerçek adı neyse onu yaz
            frm.ShowDialog(); // İstersen Show() da olabilir
        }

        private void tsmHarcamaListesi_Click(object sender, EventArgs e)
        {
            FrmHarcamaListesi frm = new FrmHarcamaListesi();
            frm.ShowDialog(); // modal olarak açılır
        }

        private void tsmKisiselRapor_Click(object sender, EventArgs e)
        {
            var raporForm = new FrmKisiBazliRapor();
            raporForm.ShowDialog();
        }



        private void tsmVerileriTemizle_Click_1(object sender, EventArgs e)
        {
            var onay = MessageBox.Show("Tüm harcamalar ve taksitler silinecek. Emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (onay != DialogResult.Yes)
                return;

            using (var db = new BudgetContext())
            {
                // Önce taksitler silinmeli (yabancı anahtar bağımlılığı nedeniyle)
                db.Taksitler.RemoveRange(db.Taksitler);
                db.Harcamalar.RemoveRange(db.Harcamalar);
                db.SaveChanges();
            }

            MessageBox.Show("Veriler temizlendi.");
        }
        private void tsmKartEkstresi_Click(object sender, EventArgs e)
        {
            var frm = new FrmKartExtre(); frm.ShowDialog();
        }
        private void tsmBankaEkle_Click(object sender, EventArgs e)
        {
            var BankaForm = new FrmBankaGiris();
            BankaForm.ShowDialog();
        }

        private void tsmKrediKartEkle_Click(object sender, EventArgs e)
        {
            var KrediKartForm = new FrmKrediKartGiris();
            KrediKartForm.ShowDialog();
        }

        private void tsmKisiEkle_Click(object sender, EventArgs e)
        {
            var KisiEkleForm = new FrmKisiEkle();
            KisiEkleForm.ShowDialog();
        }

        private void tsmBakiyeListesi_Click(object sender, EventArgs e)
        {
            var frm = new FrmBakiyeTakip();
            frm.ShowDialog();
        }
        /* private void kişiDetayToolStripMenuItem_Click(object sender, EventArgs e)
         {
             int kisiId = 5; // test için geçici bir kullanıcı ID’si
             string donem = "2025-08"; // test için örnek dönem

             var frm = new FrmKisiDetay(kisiId, donem);
             frm.ShowDialog();
         }*/
        private void FrmToolStreepMenu_Load(object sender, EventArgs e)
        {
            menuStrip1 = new MenuStrip();

            // TANIMLAR
            tsmTanımlar = new ToolStripMenuItem("Tanımlar");
            tsmKisiEkle = new ToolStripMenuItem("Kişi Ekle", null, tsmKisiEkle_Click);
            tsmBankaEkle = new ToolStripMenuItem("Banka Ekle", null, tsmBankaEkle_Click);
            tsmKrediKartEkle = new ToolStripMenuItem("Kredi Kartı Ekle", null, tsmKrediKartEkle_Click);
            tsmKategoriEkle = new ToolStripMenuItem("Kategori Ekle", null, tsmKategoriEkle_Click);
            tsmTanımlar.DropDownItems.AddRange(new ToolStripItem[] { tsmKisiEkle, tsmBankaEkle, tsmKrediKartEkle, tsmKategoriEkle });

            // HARCAMALAR
            tsmHarcamalar = new ToolStripMenuItem("Harcamalar");
            tsmHarcamaEkle = new ToolStripMenuItem("Harcama Ekle", null, tsmHarcamaEkle_Click);
            tsmHarcamaListesi = new ToolStripMenuItem("Harcama Listesi", null, tsmHarcamaListesi_Click);
            tsmHarcamaGiriş = new ToolStripMenuItem("Ödeme Giriş", null, tsmOdemeGiris_Click);
            tsmodemeRapor = new ToolStripMenuItem("Ödeme Rapor", null, tsmOdemeRapor_Click);
            tsmHarcamalar.DropDownItems.AddRange(new ToolStripItem[] { tsmHarcamaEkle, tsmHarcamaListesi, tsmHarcamaGiriş, tsmodemeRapor });

            // RAPORLAR
            tsmRaporlar = new ToolStripMenuItem("Raporlar");
            tsmAylikRapor = new ToolStripMenuItem("Aylık Rapor", null, tsmAylikRapor_Click);
            tsmKisiselRapor = new ToolStripMenuItem("Kişisel Rapor", null, tsmKisiselRapor_Click);

            tsmKategoriRaporu = new ToolStripMenuItem("Kategori Raporu", null, tsmKategoriRaporu_Click);
            tsmBakiyeListesi = new ToolStripMenuItem("Bakiye Takip", null, tsmBakiyeListesi_Click);
            tsmRaporlar.DropDownItems.AddRange(new ToolStripItem[] { tsmAylikRapor, tsmKisiselRapor, tsmKategoriRaporu, tsmBakiyeListesi });

            // YÖNETİM
            tsmYonetim = new ToolStripMenuItem("Yönetim");
            tsmVeriTemizleme = new ToolStripMenuItem("Verileri Temizle", null, tsmVeriTemizle_Click);
            tsmYonetim.DropDownItems.Add(tsmVeriTemizleme);




        }

        private void taksitTakipListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmTaksitTakip();
            frm.ShowDialog();
        }

        private void programıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmKategoriRaporu_Click_1(object sender, EventArgs e)
        {
            var frm = new FrmKategoriRapor();
            frm.ShowDialog();
        }

        private void odemeTakipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kisiId = 1; // test için geçici bir kullanıcı ID’si
            string donem = "2025-08"; // test için örnek dönem

            var frm = new FrmKisiDetay(kisiId, donem);
            frm.ShowDialog();
        }
    }
}

