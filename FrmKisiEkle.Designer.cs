namespace MyBudgetUI
{
    partial class FrmKisiEkle
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
            txtAd = new TextBox();
            label1 = new Label();
            cmbRol = new ComboBox();
            btnEkle = new Button();
            dgvKisiler = new DataGridView();
            btnGuncelle = new Button();
            btnSil = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKisiler).BeginInit();
            SuspendLayout();
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new Point(28, 21);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(28, 20);
            lblAd.TabIndex = 0;
            lblAd.Text = "Ad";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(88, 18);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(134, 27);
            txtAd.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 59);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 2;
            label1.Text = "Rol";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.DropDownWidth = 150;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(87, 50);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(152, 28);
            cmbRol.TabIndex = 3;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(274, 15);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(130, 30);
            btnEkle.TabIndex = 4;
            btnEkle.Text = "Kisi Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // dgvKisiler
            // 
            dgvKisiler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKisiler.Location = new Point(36, 97);
            dgvKisiler.Name = "dgvKisiler";
            dgvKisiler.RowHeadersWidth = 51;
            dgvKisiler.Size = new Size(482, 336);
            dgvKisiler.TabIndex = 5;
            dgvKisiler.CellClick += dgvKisiler_CellClick;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(36, 446);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(142, 34);
            btnGuncelle.TabIndex = 6;
            btnGuncelle.Text = "Guncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Visible = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(194, 447);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(141, 35);
            btnSil.TabIndex = 7;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Visible = false;
            btnSil.Click += btnSil_Click;
            // 
            // FrmKisiEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 531);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(dgvKisiler);
            Controls.Add(btnEkle);
            Controls.Add(cmbRol);
            Controls.Add(label1);
            Controls.Add(txtAd);
            Controls.Add(lblAd);
            Name = "FrmKisiEkle";
            Text = "FrmKisiEkle";
            Load += FrmKisiGiris_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKisiler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAd;
        private TextBox txtAd;
        private Label label1;
        private ComboBox cmbRol;
        private Button btnEkle;
        private DataGridView dgvKisiler;
        private Button btnGuncelle;
        private Button btnSil;
        // private Button btnEkle;
    }
}