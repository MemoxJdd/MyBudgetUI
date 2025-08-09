namespace MyBudgetUI
{
    partial class FrmKisiBazliRapor
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
            cmbKisi = new ComboBox();
            cmbDonem = new ComboBox();
            btnListele = new Button();
            dgvKartOzet = new DataGridView();
            lblToplam = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKartOzet).BeginInit();
            SuspendLayout();
            // 
            // cmbKisi
            // 
            cmbKisi.FormattingEnabled = true;
            cmbKisi.Location = new Point(27, 13);
            cmbKisi.Name = "cmbKisi";
            cmbKisi.Size = new Size(171, 28);
            cmbKisi.TabIndex = 0;
            // 
            // cmbDonem
            // 
            cmbDonem.FormattingEnabled = true;
            cmbDonem.Location = new Point(240, 13);
            cmbDonem.Name = "cmbDonem";
            cmbDonem.Size = new Size(171, 28);
            cmbDonem.TabIndex = 1;
            // 
            // btnListele
            // 
            btnListele.Location = new Point(440, 13);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(158, 35);
            btnListele.TabIndex = 2;
            btnListele.Text = "Listele";
            btnListele.UseVisualStyleBackColor = true;
            btnListele.Click += btnListele_Click;
            // 
            // dgvKartOzet
            // 
            dgvKartOzet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKartOzet.Location = new Point(10, 60);
            dgvKartOzet.Name = "dgvKartOzet";
            dgvKartOzet.RowHeadersWidth = 60;
            dgvKartOzet.Size = new Size(930, 351);
            dgvKartOzet.TabIndex = 3;
            // 
            // lblToplam
            // 
            lblToplam.AutoSize = true;
            lblToplam.Location = new Point(642, 14);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(59, 20);
            lblToplam.TabIndex = 4;
            lblToplam.Text = "Toplam";
            // 
            // FrmKisiBazliRapor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 520);
            Controls.Add(lblToplam);
            Controls.Add(dgvKartOzet);
            Controls.Add(btnListele);
            Controls.Add(cmbDonem);
            Controls.Add(cmbKisi);
            Name = "FrmKisiBazliRapor";
            Text = "FrmKisiBazliRapor";
           // FormClosing += FrmKisiBazliRapor_FormClosing;
            Load += FrmKisiBazliRapor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKartOzet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbKisi;
        private ComboBox cmbDonem;
        private Button btnListele;
        private DataGridView dgvKartOzet;
        private Label lblToplam;
    }
}