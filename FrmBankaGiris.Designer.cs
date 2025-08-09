namespace MyBudgetUI
{
    partial class FrmBankaGiris
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
            txtBankaAdi = new TextBox();
            btnEkle = new Button();
            btnSil = new Button();
            dgvBankalar = new DataGridView();
            lblBankaAdi = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBankalar).BeginInit();
            SuspendLayout();
            // 
            // txtBankaAdi
            // 
            txtBankaAdi.Location = new Point(169, 43);
            txtBankaAdi.Name = "txtBankaAdi";
            txtBankaAdi.Size = new Size(208, 27);
            txtBankaAdi.TabIndex = 0;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(403, 41);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(148, 29);
            btnEkle.TabIndex = 1;
            btnEkle.Text = "Banka Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(594, 41);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(140, 29);
            btnSil.TabIndex = 2;
            btnSil.Text = "Banka Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // dgvBankalar
            // 
            dgvBankalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBankalar.Location = new Point(37, 79);
            dgvBankalar.Name = "dgvBankalar";
            dgvBankalar.RowHeadersWidth = 51;
            dgvBankalar.Size = new Size(717, 252);
            dgvBankalar.TabIndex = 3;
            // 
            // lblBankaAdi
            // 
            lblBankaAdi.AutoSize = true;
            lblBankaAdi.Location = new Point(37, 46);
            lblBankaAdi.Name = "lblBankaAdi";
            lblBankaAdi.Size = new Size(76, 20);
            lblBankaAdi.TabIndex = 4;
            lblBankaAdi.Text = "Banka Adı";
            // 
            // FrmBankaGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBankaAdi);
            Controls.Add(dgvBankalar);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(txtBankaAdi);
            Name = "FrmBankaGiris";
            Text = "FrmBankaGiris";
            Load += FrmBankaGiris_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBankalar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBankaAdi;
        private Button btnEkle;
        private Button btnSil;
        private DataGridView dgvBankalar;
        private Label lblBankaAdi;
    }
}