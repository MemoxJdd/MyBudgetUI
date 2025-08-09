namespace MyBudgetUI
{
    partial class FrmTaksitTakip
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
            dgvTaksitDurum = new DataGridView();
            btnListele = new Button();
            cmbKisiler = new ComboBox();
            lblKisisec = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTaksitDurum).BeginInit();
            SuspendLayout();
            // 
            // dgvTaksitDurum
            // 
            dgvTaksitDurum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaksitDurum.Location = new Point(-2, 49);
            dgvTaksitDurum.Name = "dgvTaksitDurum";
            dgvTaksitDurum.RowHeadersWidth = 51;
            dgvTaksitDurum.Size = new Size(1048, 713);
            dgvTaksitDurum.TabIndex = 0;
            // 
            // btnListele
            // 
            btnListele.Location = new Point(304, 8);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(114, 35);
            btnListele.TabIndex = 1;
            btnListele.Text = "Listele";
            btnListele.UseVisualStyleBackColor = true;
            btnListele.Click += btnListele_Click;
            // 
            // cmbKisiler
            // 
            cmbKisiler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKisiler.FormattingEnabled = true;
            cmbKisiler.Location = new Point(124, 15);
            cmbKisiler.Name = "cmbKisiler";
            cmbKisiler.Size = new Size(155, 28);
            cmbKisiler.TabIndex = 2;
            // 
            // lblKisisec
            // 
            lblKisisec.AutoSize = true;
            lblKisisec.Location = new Point(21, 23);
            lblKisisec.Name = "lblKisisec";
            lblKisisec.Size = new Size(59, 20);
            lblKisisec.TabIndex = 3;
            lblKisisec.Text = "Kişi Seç";
            // 
            // FrmTaksitTakip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 774);
            Controls.Add(lblKisisec);
            Controls.Add(cmbKisiler);
            Controls.Add(btnListele);
            Controls.Add(dgvTaksitDurum);
            Name = "FrmTaksitTakip";
            Text = "FrmTaksitTakip";
            Load += FrmTaksitTakip_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTaksitDurum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTaksitDurum;
        private Button btnListele;
        private ComboBox cmbKisiler;
        private Label lblKisisec;
    }
}