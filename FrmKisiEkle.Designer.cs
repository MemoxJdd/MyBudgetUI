namespace MyBudgetUI
{
    partial class FrmKisiEkle
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRol;

        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;

        private System.Windows.Forms.DataGridView dgvKisiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRol;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAd = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();

            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();

            this.dgvKisiler = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRol = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKisiler)).BeginInit();
            this.SuspendLayout();

            // lblAd
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(18, 18);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(28, 15);
            this.lblAd.Text = "Ad:";

            // txtAd
            this.txtAd.Location = new System.Drawing.Point(60, 15);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(220, 23);

            // lblRol
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(300, 18);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(28, 15);
            this.lblRol.Text = "Rol:";

            // cmbRol
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Location = new System.Drawing.Point(337, 15);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(160, 23);

            // btnEkle
            this.btnEkle.Location = new System.Drawing.Point(520, 12);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(80, 27);
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);

            // btnGuncelle
            this.btnGuncelle.Location = new System.Drawing.Point(606, 12);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(80, 27);
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
            this.btnSil.Location = new System.Drawing.Point(692, 12);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(80, 27);
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // btnTemizle
            this.btnTemizle.Location = new System.Drawing.Point(778, 12);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(80, 27);
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);

            // dgvKisiler
            this.dgvKisiler.AllowUserToAddRows = false;
            this.dgvKisiler.AllowUserToDeleteRows = false;
            this.dgvKisiler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                            | System.Windows.Forms.AnchorStyles.Left)
                                            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKisiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKisiler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colAd, this.colRol});
            this.dgvKisiler.Location = new System.Drawing.Point(18, 55);
            this.dgvKisiler.MultiSelect = false;
            this.dgvKisiler.Name = "dgvKisiler";
            this.dgvKisiler.ReadOnly = true;
            this.dgvKisiler.RowHeadersVisible = false;
            this.dgvKisiler.RowTemplate.Height = 25;
            this.dgvKisiler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKisiler.Size = new System.Drawing.Size(840, 420);
            this.dgvKisiler.SelectionChanged += new System.EventHandler(this.dgvKisiler_SelectionChanged);

            // colId
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;

            // colAd
            this.colAd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAd.DataPropertyName = "Ad";
            this.colAd.HeaderText = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.ReadOnly = true;

            // colRol
            this.colRol.DataPropertyName = "Rol";
            this.colRol.HeaderText = "Rol";
            this.colRol.Name = "colRol";
            this.colRol.ReadOnly = true;
            this.colRol.Width = 150;

            // FrmKisiEkle
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 490);
            this.Controls.Add(this.dgvKisiler);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.lblAd);
            this.Name = "FrmKisiEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kişi Ekle / Güncelle";
            this.Load += new System.EventHandler(this.FrmKisiEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKisiler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
