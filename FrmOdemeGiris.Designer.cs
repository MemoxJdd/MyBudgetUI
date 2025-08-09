namespace MyBudgetUI
{
    partial class FrmOdemeGiris
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
            lblKisi = new Label();
            cmbKisi = new ComboBox();
            lblTarih = new Label();
            txtAciklama = new TextBox();
            lblAciklama = new Label();
            txtTutar = new TextBox();
            lblTutar = new Label();
            btnKaydet = new Button();
            dtpTarih = new DateTimePicker();
            SuspendLayout();
            // 
            // lblKisi
            // 
            lblKisi.AutoSize = true;
            lblKisi.Location = new Point(21, 42);
            lblKisi.Name = "lblKisi";
            lblKisi.Size = new Size(32, 20);
            lblKisi.TabIndex = 0;
            lblKisi.Text = "Kişi";
            // 
            // cmbKisi
            // 
            cmbKisi.FormattingEnabled = true;
            cmbKisi.Location = new Point(100, 34);
            cmbKisi.Name = "cmbKisi";
            cmbKisi.Size = new Size(161, 28);
            cmbKisi.TabIndex = 1;
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Location = new Point(21, 74);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(40, 20);
            lblTarih.TabIndex = 2;
            lblTarih.Text = "Tarih";
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(100, 107);
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(187, 27);
            txtAciklama.TabIndex = 4;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.Location = new Point(21, 114);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(70, 20);
            lblAciklama.TabIndex = 5;
            lblAciklama.Text = "Açıklama";
            // 
            // txtTutar
            // 
            txtTutar.Location = new Point(100, 147);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(174, 27);
            txtTutar.TabIndex = 6;
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Location = new Point(21, 147);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(43, 20);
            lblTutar.TabIndex = 7;
            lblTutar.Text = "Tutar";
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(100, 190);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(114, 35);
            btnKaydet.TabIndex = 8;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // dtpTarih
            // 
            dtpTarih.Format = DateTimePickerFormat.Short;
            dtpTarih.Location = new Point(102, 74);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(172, 27);
            dtpTarih.TabIndex = 10;
            // 
            // FrmOdemeGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 433);
            Controls.Add(dtpTarih);
            Controls.Add(btnKaydet);
            Controls.Add(lblTutar);
            Controls.Add(txtTutar);
            Controls.Add(lblAciklama);
            Controls.Add(txtAciklama);
            Controls.Add(lblTarih);
            Controls.Add(cmbKisi);
            Controls.Add(lblKisi);
            Name = "FrmOdemeGiris";
            Text = "FrmOdemeler";
            Load += FrmOdemeGiris_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKisi;
        private ComboBox cmbKisi;
        private Label lblTarih;
        private TextBox txtAciklama;
        private Label lblAciklama;
        private TextBox txtTutar;
        private Label lblTutar;
        private Button btnKaydet;
        private Button btnOdemeRapor;
        private DateTimePicker dtpTarih;
    }
}