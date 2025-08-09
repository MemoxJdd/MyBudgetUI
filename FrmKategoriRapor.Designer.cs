namespace MyBudgetUI
{
    partial class FrmKategoriRapor
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
            cmbDonem = new ComboBox();
            btnListele = new Button();
            dgvKategoriRapor = new DataGridView();
            lblToplam = new Label();
            btnGrafikGoster = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKategoriRapor).BeginInit();
            SuspendLayout();
            // 
            // cmbDonem
            // 
            cmbDonem.FormattingEnabled = true;
            cmbDonem.Location = new Point(64, 17);
            cmbDonem.Name = "cmbDonem";
            cmbDonem.Size = new Size(170, 28);
            cmbDonem.TabIndex = 0;
            // 
            // btnListele
            // 
            btnListele.Location = new Point(284, 19);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(94, 29);
            btnListele.TabIndex = 1;
            btnListele.Text = "Listele";
            btnListele.UseVisualStyleBackColor = true;
            btnListele.Click += btnListele_Click;
            // 
            // dgvKategoriRapor
            // 
            dgvKategoriRapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKategoriRapor.Location = new Point(27, 68);
            dgvKategoriRapor.Name = "dgvKategoriRapor";
            dgvKategoriRapor.RowHeadersWidth = 51;
            dgvKategoriRapor.Size = new Size(588, 505);
            dgvKategoriRapor.TabIndex = 2;
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Location = new Point(425, 28);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(59, 20);
            lblToplam.TabIndex = 3;
            lblToplam.Text = "Toplam";
            // 
            // btnGrafikGoster
            // 
            btnGrafikGoster.Location = new Point(41, 590);
            btnGrafikGoster.Name = "btnGrafikGoster";
            btnGrafikGoster.Size = new Size(147, 29);
            btnGrafikGoster.TabIndex = 4;
            btnGrafikGoster.Text = "Grafik Göster";
            btnGrafikGoster.UseVisualStyleBackColor = true;
            btnGrafikGoster.Click += btnGrafikGoster_Click;
            // 
            // FrmKategoriRapor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 709);
            Controls.Add(btnGrafikGoster);
            Controls.Add(lblToplam);
            Controls.Add(dgvKategoriRapor);
            Controls.Add(btnListele);
            Controls.Add(cmbDonem);
            Name = "FrmKategoriRapor";
            Text = "FrmKategoriRapor";
            Load += FrmKategoriRapor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKategoriRapor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDonem;
        private Button btnListele;
        private DataGridView dgvKategoriRapor;
        private Label lblToplam;
        private Button btnGrafikGoster;
    }
}