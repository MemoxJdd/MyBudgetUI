namespace MyBudgetUI
{
    partial class FrmOdemeListesi
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
            btnListele = new Button();
            dgvListe = new DataGridView();
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            btnGuncelle = new Button();
            btnSil = new Button();
            lblToplam = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvListe).BeginInit();
            SuspendLayout();
            // 
            // btnListele
            // 
            btnListele.Font = new Font("Segoe UI", 10F);
            btnListele.Location = new Point(402, 9);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(147, 29);
            btnListele.TabIndex = 2;
            btnListele.Text = "Filtrele";
            btnListele.UseVisualStyleBackColor = true;
            btnListele.Click += btnListele_Click;
            // 
            // dgvListe
            // 
            dgvListe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListe.Location = new Point(21, 54);
            dgvListe.Name = "dgvListe";
            dgvListe.RowHeadersWidth = 51;
            dgvListe.Size = new Size(707, 423);
            dgvListe.TabIndex = 3;
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Font = new Font("Segoe UI", 10F);
            dtpBaslangic.Format = DateTimePickerFormat.Short;
            dtpBaslangic.Location = new Point(21, 12);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(171, 30);
            dtpBaslangic.TabIndex = 4;
            dtpBaslangic.ValueChanged += dtpBaslangic_ValueChanged;
            // 
            // dtpBitis
            // 
            dtpBitis.Font = new Font("Segoe UI", 10F);
            dtpBitis.Format = DateTimePickerFormat.Short;
            dtpBitis.Location = new Point(226, 11);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(148, 30);
            dtpBitis.TabIndex = 5;
            dtpBitis.ValueChanged += dtpBitis_ValueChanged;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Font = new Font("Segoe UI", 10F);
            btnGuncelle.Location = new Point(21, 497);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(140, 40);
            btnGuncelle.TabIndex = 6;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Font = new Font("Segoe UI", 10F);
            btnSil.Location = new Point(201, 498);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 44);
            btnSil.TabIndex = 7;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Font = new Font("Segoe UI", 10F);
            lblToplam.Location = new Point(595, 17);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(65, 23);
            lblToplam.TabIndex = 8;
            lblToplam.Text = "Toplam";
            // 
            // FrmOdemeListesi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 768);
            Controls.Add(lblToplam);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(dtpBitis);
            Controls.Add(dtpBaslangic);
            Controls.Add(dgvListe);
            Controls.Add(btnListele);
            Name = "FrmOdemeListesi";
            Text = "FrmOdemeListesi";
            Load += FrmOdemeListesi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnListele;
        private DataGridView dgvListe;
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private Button btnGuncelle;
        private Button btnSil;
        private Label lblToplam;
    }
}