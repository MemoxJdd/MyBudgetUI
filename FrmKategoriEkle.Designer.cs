namespace MyBudgetUI
{
    partial class FrmKategoriEkle
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
            txtAd = new TextBox();
            lblAd = new Label();
            btnKaydet = new Button();
            dgvKategoriler = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKategoriler).BeginInit();
            SuspendLayout();
            // 
            // txtAd
            // 
            txtAd.Location = new Point(101, 15);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(176, 27);
            txtAd.TabIndex = 0;
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new Point(12, 22);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(28, 20);
            lblAd.TabIndex = 1;
            lblAd.Text = "Ad";
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(357, 8);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(138, 33);
            btnKaydet.TabIndex = 2;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // dgvKategoriler
            // 
            dgvKategoriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKategoriler.Location = new Point(26, 68);
            dgvKategoriler.Name = "dgvKategoriler";
            dgvKategoriler.RowHeadersWidth = 51;
            dgvKategoriler.Size = new Size(477, 602);
            dgvKategoriler.TabIndex = 3;
            // 
            // FrmKategoriEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 733);
            Controls.Add(dgvKategoriler);
            Controls.Add(btnKaydet);
            Controls.Add(lblAd);
            Controls.Add(txtAd);
            Name = "FrmKategoriEkle";
            Text = "FrmKategoriEkle";
            Load += FrmKategoriEkle_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKategoriler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAd;
        private Label lblAd;
        private Button btnKaydet;
        private DataGridView dgvKategoriler;
    }
}