namespace MyBudgetUI
{
    partial class FrmHarcamaGiris
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
            cmbKisi = new ComboBox();
            cmbKart = new ComboBox();
            dtpTarih = new DateTimePicker();
            txtTutar = new TextBox();
            txtAciklama = new TextBox();
            nudTaksitSayisi = new NumericUpDown();
            chkOrtakMi = new CheckBox();
            btnKaydet = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            cmbKategori = new ComboBox();
            lblKategori = new Label();
            ((System.ComponentModel.ISupportInitialize)nudTaksitSayisi).BeginInit();
            SuspendLayout();
            // 
            // cmbKisi
            // 
            cmbKisi.Font = new Font("Segoe UI", 12F);
            cmbKisi.FormattingEnabled = true;
            cmbKisi.Location = new Point(130, 40);
            cmbKisi.Margin = new Padding(3, 4, 3, 4);
            cmbKisi.Name = "cmbKisi";
            cmbKisi.Size = new Size(180, 36);
            cmbKisi.TabIndex = 0;
            // 
            // cmbKart
            // 
            cmbKart.Font = new Font("Segoe UI", 12F);
            cmbKart.FormattingEnabled = true;
            cmbKart.Location = new Point(130, 85);
            cmbKart.Margin = new Padding(3, 4, 3, 4);
            cmbKart.Name = "cmbKart";
            cmbKart.Size = new Size(280, 36);
            cmbKart.TabIndex = 1;
            // 
            // dtpTarih
            // 
            dtpTarih.Font = new Font("Segoe UI", 12F);
            dtpTarih.Location = new Point(130, 129);
            dtpTarih.Margin = new Padding(3, 4, 3, 4);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(280, 34);
            dtpTarih.TabIndex = 2;
            // 
            // txtTutar
            // 
            txtTutar.Font = new Font("Segoe UI", 12F);
            txtTutar.Location = new Point(130, 171);
            txtTutar.Margin = new Padding(3, 4, 3, 4);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(180, 34);
            txtTutar.TabIndex = 3;
            // 
            // txtAciklama
            // 
            txtAciklama.Font = new Font("Segoe UI", 12F);
            txtAciklama.Location = new Point(130, 211);
            txtAciklama.Margin = new Padding(3, 4, 3, 4);
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(180, 34);
            txtAciklama.TabIndex = 4;
            // 
            // nudTaksitSayisi
            // 
            nudTaksitSayisi.Font = new Font("Segoe UI", 12F);
            nudTaksitSayisi.Location = new Point(130, 295);
            nudTaksitSayisi.Margin = new Padding(3, 4, 3, 4);
            nudTaksitSayisi.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudTaksitSayisi.Name = "nudTaksitSayisi";
            nudTaksitSayisi.Size = new Size(180, 34);
            nudTaksitSayisi.TabIndex = 6;
            // 
            // chkOrtakMi
            // 
            chkOrtakMi.AutoSize = true;
            chkOrtakMi.Font = new Font("Segoe UI", 12F);
            chkOrtakMi.Location = new Point(130, 348);
            chkOrtakMi.Margin = new Padding(3, 4, 3, 4);
            chkOrtakMi.Name = "chkOrtakMi";
            chkOrtakMi.Size = new Size(110, 32);
            chkOrtakMi.TabIndex = 7;
            chkOrtakMi.Text = "Ortak mi";
            chkOrtakMi.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Font = new Font("Segoe UI", 12F);
            btnKaydet.Location = new Point(130, 388);
            btnKaydet.Margin = new Padding(3, 4, 3, 4);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(95, 40);
            btnKaydet.TabIndex = 8;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(10, 49);
            label1.Name = "label1";
            label1.Size = new Size(42, 28);
            label1.TabIndex = 8;
            label1.Text = "Kişi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(10, 93);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 9;
            label2.Text = "Kredi Kart";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(10, 134);
            label3.Name = "label3";
            label3.Size = new Size(53, 28);
            label3.TabIndex = 10;
            label3.Text = "Tarih";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(10, 177);
            label4.Name = "label4";
            label4.Size = new Size(57, 28);
            label4.TabIndex = 11;
            label4.Text = "Tutar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(10, 217);
            label5.Name = "label5";
            label5.Size = new Size(91, 28);
            label5.TabIndex = 12;
            label5.Text = "Açiklama";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(10, 297);
            label6.Name = "label6";
            label6.Size = new Size(114, 28);
            label6.TabIndex = 13;
            label6.Text = "Taksit Sayısı";
            // 
            // button1
            // 
            button1.Location = new Point(482, 79);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 14;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // cmbKategori
            // 
            cmbKategori.Font = new Font("Segoe UI", 12F);
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(130, 252);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(180, 36);
            cmbKategori.TabIndex = 5;
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Font = new Font("Segoe UI", 12F);
            lblKategori.Location = new Point(10, 260);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(87, 28);
            lblKategori.TabIndex = 16;
            lblKategori.Text = "Kategori";
            // 
            // FrmHarcamaGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 507);
            Controls.Add(lblKategori);
            Controls.Add(cmbKategori);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnKaydet);
            Controls.Add(chkOrtakMi);
            Controls.Add(nudTaksitSayisi);
            Controls.Add(txtAciklama);
            Controls.Add(txtTutar);
            Controls.Add(dtpTarih);
            Controls.Add(cmbKart);
            Controls.Add(cmbKisi);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmHarcamaGiris";
            Text = "Harcama";
            Load += FrmHarcamaGiris_Load;
            ((System.ComponentModel.ISupportInitialize)nudTaksitSayisi).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbKisi;
        public System.Windows.Forms.ComboBox cmbKart;
        public System.Windows.Forms.DateTimePicker dtpTarih;
        public System.Windows.Forms.TextBox txtTutar;
        public System.Windows.Forms.TextBox txtAciklama;
        public System.Windows.Forms.NumericUpDown nudTaksitSayisi;
        public System.Windows.Forms.CheckBox chkOrtakMi;
        public System.Windows.Forms.Button btnKaydet;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private ComboBox cmbKategori;
        private Label lblKategori;
    }
}