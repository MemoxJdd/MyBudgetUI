namespace MyBudgetUI
{
    partial class FrmKisiDetay
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
            lblAd = new Label();
            dgvHarcamaDetay = new DataGridView();
            dgvOdemeDetay = new DataGridView();
            lblToplamHarcama = new Label();
            lblToplamOdeme = new Label();
            lblNetBakiye = new Label();
            lblHarcama = new Label();
            lblOdeme = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHarcamaDetay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOdemeDetay).BeginInit();
            SuspendLayout();
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Segoe UI", 12F);
            lblAd.Location = new Point(49, 9);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(37, 28);
            lblAd.TabIndex = 0;
            lblAd.Text = "Ad";
            // 
            // dgvHarcamaDetay
            // 
            dgvHarcamaDetay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHarcamaDetay.Location = new Point(49, 61);
            dgvHarcamaDetay.Name = "dgvHarcamaDetay";
            dgvHarcamaDetay.RowHeadersWidth = 51;
            dgvHarcamaDetay.Size = new Size(550, 631);
            dgvHarcamaDetay.TabIndex = 1;
            // 
            // dgvOdemeDetay
            // 
            dgvOdemeDetay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOdemeDetay.Location = new Point(635, 61);
            dgvOdemeDetay.Name = "dgvOdemeDetay";
            dgvOdemeDetay.RowHeadersWidth = 51;
            dgvOdemeDetay.Size = new Size(550, 631);
            dgvOdemeDetay.TabIndex = 2;
            // 
            // lblToplamHarcama
            // 
            lblToplamHarcama.AutoSize = true;
            lblToplamHarcama.Font = new Font("Segoe UI", 12F);
            lblToplamHarcama.Location = new Point(244, 9);
            lblToplamHarcama.Name = "lblToplamHarcama";
            lblToplamHarcama.Size = new Size(158, 28);
            lblToplamHarcama.TabIndex = 3;
            lblToplamHarcama.Text = "Toplam Harcama";
            // 
            // lblToplamOdeme
            // 
            lblToplamOdeme.AutoSize = true;
            lblToplamOdeme.Font = new Font("Segoe UI", 12F);
            lblToplamOdeme.Location = new Point(713, 9);
            lblToplamOdeme.Name = "lblToplamOdeme";
            lblToplamOdeme.Size = new Size(145, 28);
            lblToplamOdeme.TabIndex = 4;
            lblToplamOdeme.Text = "Toplam Odeme";
            // 
            // lblNetBakiye
            // 
            lblNetBakiye.AutoSize = true;
            lblNetBakiye.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNetBakiye.Location = new Point(635, 695);
            lblNetBakiye.Name = "lblNetBakiye";
            lblNetBakiye.Size = new Size(116, 28);
            lblNetBakiye.TabIndex = 5;
            lblNetBakiye.Text = "Net Bakiye";
            // 
            // lblHarcama
            // 
            lblHarcama.AutoSize = true;
            lblHarcama.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHarcama.Location = new Point(49, 38);
            lblHarcama.Name = "lblHarcama";
            lblHarcama.Size = new Size(135, 23);
            lblHarcama.TabIndex = 6;
            lblHarcama.Text = "Harcama Listesi";
            // 
            // lblOdeme
            // 
            lblOdeme.AutoSize = true;
            lblOdeme.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOdeme.Location = new Point(635, 38);
            lblOdeme.Name = "lblOdeme";
            lblOdeme.Size = new Size(122, 23);
            lblOdeme.TabIndex = 7;
            lblOdeme.Text = "Ödeme Listesi";
            // 
            // FrmKisiDetay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 768);
            Controls.Add(lblOdeme);
            Controls.Add(lblHarcama);
            Controls.Add(lblNetBakiye);
            Controls.Add(lblToplamOdeme);
            Controls.Add(lblToplamHarcama);
            Controls.Add(dgvOdemeDetay);
            Controls.Add(dgvHarcamaDetay);
            Controls.Add(lblAd);
            Name = "FrmKisiDetay";
            Text = "FrmKisiDetay";
            Load += FrmKisiDetay_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHarcamaDetay).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOdemeDetay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAd;
        private DataGridView dgvHarcamaDetay;
        private DataGridView dgvOdemeDetay;
        private Label lblToplamHarcama;
        private Label lblToplamOdeme;
        private Label lblNetBakiye;
        private Label lblHarcama;
        private Label lblOdeme;
    }
}