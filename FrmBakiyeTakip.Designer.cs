
namespace MyBudgetUI
{
    partial class FrmBakiyeTakip
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
            dgvBakiyeListesi = new DataGridView();
            btnHesapla = new Button();
            dtpAySecimi = new DateTimePicker();
            lblToplam = new Label();
            btnExceleAktar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBakiyeListesi).BeginInit();
            SuspendLayout();
            // 
            // dgvBakiyeListesi
            // 
            dgvBakiyeListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBakiyeListesi.Location = new Point(18, 54);
            dgvBakiyeListesi.Name = "dgvBakiyeListesi";
            dgvBakiyeListesi.RowHeadersWidth = 51;
            dgvBakiyeListesi.Size = new Size(774, 366);
            dgvBakiyeListesi.TabIndex = 0;           
            dgvBakiyeListesi.CellDoubleClick += dgvBakiyeListesi_CellDoubleClick;
            dgvBakiyeListesi.CellFormatting += dgvListe_CellFormatting;
            // 
            // btnHesapla
            // 
            btnHesapla.Location = new Point(206, 16);
            btnHesapla.Name = "btnHesapla";
            btnHesapla.Size = new Size(158, 32);
            btnHesapla.TabIndex = 1;
            btnHesapla.Text = "Hesapla";
            btnHesapla.UseVisualStyleBackColor = true;
            btnHesapla.Click += btnHesapla_Click;
            // 
            // dtpAySecimi
            // 
            dtpAySecimi.Format = DateTimePickerFormat.Short;
            dtpAySecimi.Location = new Point(18, 16);
            dtpAySecimi.Name = "dtpAySecimi";
            dtpAySecimi.Size = new Size(182, 27);
            dtpAySecimi.TabIndex = 2;
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Location = new Point(18, 441);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(59, 20);
            lblToplam.TabIndex = 3;
            lblToplam.Text = "Toplam";
            // 
            // btnExceleAktar
            // 
            btnExceleAktar.Location = new Point(383, 20);
            btnExceleAktar.Name = "btnExceleAktar";
            btnExceleAktar.Size = new Size(163, 28);
            btnExceleAktar.TabIndex = 4;
            btnExceleAktar.Text = "Aktar";
            btnExceleAktar.UseVisualStyleBackColor = true;
            btnExceleAktar.Click += btnExceleAktar_Click;
            // 
            // FrmBakiyeTakip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 560);
            Controls.Add(btnExceleAktar);
            Controls.Add(lblToplam);
            Controls.Add(dtpAySecimi);
            Controls.Add(btnHesapla);
            Controls.Add(dgvBakiyeListesi);
            Name = "FrmBakiyeTakip";
            Text = "FrmBakiyeTakip";
            Load += FrmBakiyeTakip_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBakiyeListesi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBakiyeListesi;
        private Button btnHesapla;
        private DateTimePicker dtpAySecimi;
        private Label lblToplam;
        private Button btnExceleAktar;
    }
}