namespace MyBudgetUI
{
    partial class FrmToolStreepMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToolStreepMenu));
            menuStrip1 = new MenuStrip();
            tsmTanımlar = new ToolStripMenuItem();
            tsmKisiEkle = new ToolStripMenuItem();
            tsmBankaEkle = new ToolStripMenuItem();
            tsmKrediKartEkle = new ToolStripMenuItem();
            tsmKategoriEkle = new ToolStripMenuItem();
            tsmHarcamalar = new ToolStripMenuItem();
            tsmHarcamaEkle = new ToolStripMenuItem();
            tsmHarcamaListesi = new ToolStripMenuItem();
            tsmHarcamaGiriş = new ToolStripMenuItem();
            tsmodemeRapor = new ToolStripMenuItem();
            tsmRaporlar = new ToolStripMenuItem();
            tsmAylikRapor = new ToolStripMenuItem();
            tsmKisiselRapor = new ToolStripMenuItem();
            tsmKategoriRaporu = new ToolStripMenuItem();
            tsmBakiyeListesi = new ToolStripMenuItem();
            tsmKartEkstresi = new ToolStripMenuItem();
            taksitTakipListesiToolStripMenuItem = new ToolStripMenuItem();
            tsmYonetim = new ToolStripMenuItem();
            tsmVeriTemizleme = new ToolStripMenuItem();
            programıKapatToolStripMenuItem = new ToolStripMenuItem();
            odemeTakipToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmTanımlar, tsmHarcamalar, tsmRaporlar, tsmYonetim });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(11, 3, 0, 3);
            menuStrip1.Size = new Size(929, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmTanımlar
            // 
            tsmTanımlar.DropDownItems.AddRange(new ToolStripItem[] { tsmKisiEkle, tsmBankaEkle, tsmKrediKartEkle, tsmKategoriEkle });
            tsmTanımlar.Font = new Font("Garamond", 13.8F, FontStyle.Bold);
            tsmTanımlar.Name = "tsmTanımlar";
            tsmTanımlar.Size = new Size(116, 30);
            tsmTanımlar.Text = "Tanımlar";
            // 
            // tsmKisiEkle
            // 
            tsmKisiEkle.Name = "tsmKisiEkle";
            tsmKisiEkle.Size = new Size(252, 30);
            tsmKisiEkle.Text = "Kişi Ekle";
            tsmKisiEkle.Click += tsmKisiEkle_Click;
            // 
            // tsmBankaEkle
            // 
            tsmBankaEkle.Name = "tsmBankaEkle";
            tsmBankaEkle.Size = new Size(252, 30);
            tsmBankaEkle.Text = "Banka Ekle";
            tsmBankaEkle.Click += tsmBankaEkle_Click;
            // 
            // tsmKrediKartEkle
            // 
            tsmKrediKartEkle.Name = "tsmKrediKartEkle";
            tsmKrediKartEkle.Size = new Size(252, 30);
            tsmKrediKartEkle.Text = "Kredi Kart Ekle";
            tsmKrediKartEkle.Click += tsmKrediKartEkle_Click;
            // 
            // tsmKategoriEkle
            // 
            tsmKategoriEkle.Name = "tsmKategoriEkle";
            tsmKategoriEkle.Size = new Size(252, 30);
            tsmKategoriEkle.Text = "Kategori Ekle";
            tsmKategoriEkle.Click += tsmKategoriEkle_Click;
            // 
            // tsmHarcamalar
            // 
            tsmHarcamalar.DropDownItems.AddRange(new ToolStripItem[] { tsmHarcamaEkle, tsmHarcamaListesi, tsmHarcamaGiriş, tsmodemeRapor });
            tsmHarcamalar.Font = new Font("Garamond", 13.8F, FontStyle.Bold);
            tsmHarcamalar.Name = "tsmHarcamalar";
            tsmHarcamalar.Size = new Size(143, 30);
            tsmHarcamalar.Text = "Harcamalar";
            // 
            // tsmHarcamaEkle
            // 
            tsmHarcamaEkle.Name = "tsmHarcamaEkle";
            tsmHarcamaEkle.Size = new Size(260, 30);
            tsmHarcamaEkle.Text = "Harcama Ekle";
            tsmHarcamaEkle.Click += tsmHarcamaEkle_Click;
            // 
            // tsmHarcamaListesi
            // 
            tsmHarcamaListesi.Name = "tsmHarcamaListesi";
            tsmHarcamaListesi.Size = new Size(260, 30);
            tsmHarcamaListesi.Text = "Harcama Listesi";
            tsmHarcamaListesi.Click += tsmHarcamaListesi_Click;
            // 
            // tsmHarcamaGiriş
            // 
            tsmHarcamaGiriş.Name = "tsmHarcamaGiriş";
            tsmHarcamaGiriş.Size = new Size(260, 30);
            tsmHarcamaGiriş.Text = "Ödeme Giriş";
            tsmHarcamaGiriş.Click += tsmOdemeGiris_Click;
            // 
            // tsmodemeRapor
            // 
            tsmodemeRapor.Name = "tsmodemeRapor";
            tsmodemeRapor.Size = new Size(260, 30);
            tsmodemeRapor.Text = "Ödeme Rapor";
            tsmodemeRapor.Click += tsmOdemeRapor_Click;
            // 
            // tsmRaporlar
            // 
            tsmRaporlar.DropDownItems.AddRange(new ToolStripItem[] { tsmAylikRapor, tsmKisiselRapor, tsmKategoriRaporu, tsmBakiyeListesi, tsmKartEkstresi, taksitTakipListesiToolStripMenuItem, odemeTakipToolStripMenuItem });
            tsmRaporlar.Font = new Font("Garamond", 13.8F, FontStyle.Bold);
            tsmRaporlar.Name = "tsmRaporlar";
            tsmRaporlar.Size = new Size(112, 30);
            tsmRaporlar.Text = "Raporlar";
            // 
            // tsmAylikRapor
            // 
            tsmAylikRapor.Name = "tsmAylikRapor";
            tsmAylikRapor.Size = new Size(293, 30);
            tsmAylikRapor.Text = "Aylık Rapor";
            tsmAylikRapor.Click += tsmAylikRapor_Click;
            // 
            // tsmKisiselRapor
            // 
            tsmKisiselRapor.Name = "tsmKisiselRapor";
            tsmKisiselRapor.Size = new Size(293, 30);
            tsmKisiselRapor.Text = "Kişisel Rapor";
            tsmKisiselRapor.Click += tsmKisiselRapor_Click;
            // 
            // tsmKategoriRaporu
            // 
            tsmKategoriRaporu.Name = "tsmKategoriRaporu";
            tsmKategoriRaporu.Size = new Size(293, 30);
            tsmKategoriRaporu.Text = "Kategori Raporu";
            tsmKategoriRaporu.CommandCanExecuteChanged += tsmKategoriRaporu_Click;
            tsmKategoriRaporu.Click += tsmKategoriRaporu_Click_1;
            // 
            // tsmBakiyeListesi
            // 
            tsmBakiyeListesi.Name = "tsmBakiyeListesi";
            tsmBakiyeListesi.Size = new Size(293, 30);
            tsmBakiyeListesi.Text = "Bakiye Listesi";
            tsmBakiyeListesi.Click += tsmBakiyeListesi_Click;
            // 
            // tsmKartEkstresi
            // 
            tsmKartEkstresi.Name = "tsmKartEkstresi";
            tsmKartEkstresi.Size = new Size(293, 30);
            tsmKartEkstresi.Text = "Kart Ekstresi";
            tsmKartEkstresi.Click += tsmKartEkstresi_Click;
            // 
            // taksitTakipListesiToolStripMenuItem
            // 
            taksitTakipListesiToolStripMenuItem.Name = "taksitTakipListesiToolStripMenuItem";
            taksitTakipListesiToolStripMenuItem.Size = new Size(293, 30);
            taksitTakipListesiToolStripMenuItem.Text = "Taksit Takip Listesi";
            taksitTakipListesiToolStripMenuItem.Click += taksitTakipListesiToolStripMenuItem_Click;
            // 
            // tsmYonetim
            // 
            tsmYonetim.DropDownItems.AddRange(new ToolStripItem[] { tsmVeriTemizleme, programıKapatToolStripMenuItem });
            tsmYonetim.Font = new Font("Garamond", 13.8F, FontStyle.Bold);
            tsmYonetim.Name = "tsmYonetim";
            tsmYonetim.Size = new Size(109, 30);
            tsmYonetim.Text = "Yonetim";
            // 
            // tsmVeriTemizleme
            // 
            tsmVeriTemizleme.Name = "tsmVeriTemizleme";
            tsmVeriTemizleme.Size = new Size(254, 30);
            tsmVeriTemizleme.Text = "Veri Temizleme";
            tsmVeriTemizleme.Click += tsmVeriTemizle_Click;
            // 
            // programıKapatToolStripMenuItem
            // 
            programıKapatToolStripMenuItem.Name = "programıKapatToolStripMenuItem";
            programıKapatToolStripMenuItem.Size = new Size(254, 30);
            programıKapatToolStripMenuItem.Text = "Programı Kapat";
            programıKapatToolStripMenuItem.Click += programıKapatToolStripMenuItem_Click;
            // 
            // odemeTakipToolStripMenuItem
            // 
            odemeTakipToolStripMenuItem.Name = "odemeTakipToolStripMenuItem";
            odemeTakipToolStripMenuItem.Size = new Size(293, 30);
            odemeTakipToolStripMenuItem.Text = "Odeme Takip";
            odemeTakipToolStripMenuItem.Click += odemeTakipToolStripMenuItem_Click;
            // 
            // FrmToolStreepMenu
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(929, 585);
            Controls.Add(menuStrip1);
            Font = new Font("Garamond", 13.8F, FontStyle.Bold);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 4, 5, 4);
            Name = "FrmToolStreepMenu";
            Text = "Family Budget";
            Load += FrmToolStreepMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmTanımlar;
        private ToolStripMenuItem tsmKisiEkle;
        private ToolStripMenuItem tsmBankaEkle;
        private ToolStripMenuItem tsmKrediKartEkle;
        private ToolStripMenuItem tsmHarcamalar;
        private ToolStripMenuItem tsmHarcamaEkle;
        private ToolStripMenuItem tsmHarcamaListesi;
        private ToolStripMenuItem tsmHarcamaGiriş;
        private ToolStripMenuItem tsmodemeRapor;
        private ToolStripMenuItem tsmRaporlar;
        private ToolStripMenuItem tsmAylikRapor;
        private ToolStripMenuItem tsmKisiselRapor;
      
        private ToolStripMenuItem tsmYonetim;
        private ToolStripMenuItem tsmKategoriEkle;
        private ToolStripMenuItem tsmKategoriRaporu;
        private ToolStripMenuItem tsmBakiyeListesi;
        private ToolStripMenuItem tsmVeriTemizleme;
        private ToolStripMenuItem tsmKartEkstresi;
        private ToolStripMenuItem taksitTakipListesiToolStripMenuItem;
        private ToolStripMenuItem programıKapatToolStripMenuItem;
        private ToolStripMenuItem odemeTakipToolStripMenuItem;
    }
}