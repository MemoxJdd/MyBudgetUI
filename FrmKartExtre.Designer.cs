namespace MyBudgetUI
{
    partial class FrmKartExtre
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
            cmbKart = new ComboBox();
            cmbAy = new ComboBox();
            btnListele = new Button();
            dgvExtre = new DataGridView();
            lblBaslik = new Label();
            lblToplam = new Label();
            btnAktar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExtre).BeginInit();
            SuspendLayout();
            // 
            // cmbKart
            // 
            cmbKart.FormattingEnabled = true;
            cmbKart.Location = new Point(22, 46);
            cmbKart.Name = "cmbKart";
            cmbKart.Size = new Size(239, 28);
            cmbKart.TabIndex = 0;
            // 
            // cmbAy
            // 
            cmbAy.FormattingEnabled = true;
            cmbAy.Location = new Point(267, 46);
            cmbAy.Name = "cmbAy";
            cmbAy.Size = new Size(176, 28);
            cmbAy.TabIndex = 1;
            // 
            // btnListele
            // 
            btnListele.Font = new Font("Segoe UI", 12F);
            btnListele.Location = new Point(449, 46);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(186, 35);
            btnListele.TabIndex = 2;
            btnListele.Text = "Listele";
            btnListele.UseVisualStyleBackColor = true;
            btnListele.Click += btnListele_Click;
            // 
            // dgvExtre
            // 
            dgvExtre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExtre.Location = new Point(12, 98);
            dgvExtre.Name = "dgvExtre";
            dgvExtre.RowHeadersWidth = 51;
            dgvExtre.Size = new Size(747, 644);
            dgvExtre.TabIndex = 3;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Segoe UI", 16F);
            lblBaslik.Location = new Point(340, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(199, 37);
            lblBaslik.TabIndex = 5;
            lblBaslik.Text = "Kredi Kart Extre";
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Font = new Font("Segoe UI", 12F);
            lblToplam.Location = new Point(684, 51);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(76, 28);
            lblToplam.TabIndex = 6;
            lblToplam.Text = "Toplam";
            // 
            // btnAktar
            // 
            btnAktar.Location = new Point(26, 5);
            btnAktar.Name = "btnAktar";
            btnAktar.Size = new Size(138, 31);
            btnAktar.TabIndex = 7;
            btnAktar.Text = "Excell Aktar";
            btnAktar.UseVisualStyleBackColor = true;
            btnAktar.Click += btnAktar_Click;
            // 
            // FrmKartExtre
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 754);
            Controls.Add(btnAktar);
            Controls.Add(lblToplam);
            Controls.Add(lblBaslik);
            Controls.Add(dgvExtre);
            Controls.Add(btnListele);
            Controls.Add(cmbAy);
            Controls.Add(cmbKart);
            Name = "FrmKartExtre";
            Text = "FrmKartExtre";
            FormClosing += FrmKartExtre_FormClosing;
            Load += FrmKartExtre_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExtre).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbKart;
        private ComboBox cmbAy;
        private Button btnListele;
        private DataGridView dgvExtre;
        private Label lblBaslik;
        private Label lblToplam;
        private Button btnAktar;
    }
}