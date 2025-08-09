namespace MyBudgetUI
{
    partial class FrmKrediKartGiris
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
            txtKartAdi = new TextBox();
            lblKartAdi = new Label();
            cmbBanka = new ComboBox();
            lblBanka = new Label();
            lblSahip = new Label();
            cmbSahip = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnEkle = new Button();
            btnSil = new Button();
            dgvKartlar = new DataGridView();
            nudKesimGunu = new NumericUpDown();
            nudSonOdemeGunu = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvKartlar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudKesimGunu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSonOdemeGunu).BeginInit();
            SuspendLayout();
            // 
            // txtKartAdi
            // 
            txtKartAdi.Location = new Point(110, 17);
            txtKartAdi.Name = "txtKartAdi";
            txtKartAdi.Size = new Size(126, 27);
            txtKartAdi.TabIndex = 0;
            // 
            // lblKartAdi
            // 
            lblKartAdi.AutoSize = true;
            lblKartAdi.Location = new Point(12, 24);
            lblKartAdi.Name = "lblKartAdi";
            lblKartAdi.Size = new Size(63, 20);
            lblKartAdi.TabIndex = 1;
            lblKartAdi.Text = "Kart Adı";
            // 
            // cmbBanka
            // 
            cmbBanka.FormattingEnabled = true;
            cmbBanka.Location = new Point(110, 50);
            cmbBanka.Name = "cmbBanka";
            cmbBanka.Size = new Size(120, 28);
            cmbBanka.TabIndex = 2;
            // 
            // lblBanka
            // 
            lblBanka.AutoSize = true;
            lblBanka.Location = new Point(12, 58);
            lblBanka.Name = "lblBanka";
            lblBanka.Size = new Size(49, 20);
            lblBanka.TabIndex = 3;
            lblBanka.Text = "Banka";
            // 
            // lblSahip
            // 
            lblSahip.AutoSize = true;
            lblSahip.Location = new Point(12, 92);
            lblSahip.Name = "lblSahip";
            lblSahip.Size = new Size(32, 20);
            lblSahip.TabIndex = 5;
            lblSahip.Text = "Kişi";
            // 
            // cmbSahip
            // 
            cmbSahip.FormattingEnabled = true;
            cmbSahip.Location = new Point(110, 84);
            cmbSahip.Name = "cmbSahip";
            cmbSahip.Size = new Size(120, 28);
            cmbSahip.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 25);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 7;
            label1.Text = "KesimGünü";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 63);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 9;
            label2.Text = "Ödeme Günü";
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(700, 13);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(127, 30);
            btnEkle.TabIndex = 10;
            btnEkle.Text = "Kart Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(700, 58);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(127, 30);
            btnSil.TabIndex = 11;
            btnSil.Text = "Kart Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // dgvKartlar
            // 
            dgvKartlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKartlar.Location = new Point(108, 127);
            dgvKartlar.Name = "dgvKartlar";
            dgvKartlar.RowHeadersWidth = 51;
            dgvKartlar.Size = new Size(777, 453);
            dgvKartlar.TabIndex = 12;
            // 
            // nudKesimGunu
            // 
            nudKesimGunu.Location = new Point(382, 25);
            nudKesimGunu.Name = "nudKesimGunu";
            nudKesimGunu.Size = new Size(88, 27);
            nudKesimGunu.TabIndex = 13;
            // 
            // nudSonOdemeGunu
            // 
            nudSonOdemeGunu.Location = new Point(382, 58);
            nudSonOdemeGunu.Name = "nudSonOdemeGunu";
            nudSonOdemeGunu.Size = new Size(88, 27);
            nudSonOdemeGunu.TabIndex = 14;
            // 
            // FrmKrediKartGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 667);
            Controls.Add(nudSonOdemeGunu);
            Controls.Add(nudKesimGunu);
            Controls.Add(dgvKartlar);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblSahip);
            Controls.Add(cmbSahip);
            Controls.Add(lblBanka);
            Controls.Add(cmbBanka);
            Controls.Add(lblKartAdi);
            Controls.Add(txtKartAdi);
            Name = "FrmKrediKartGiris";
            Text = "FrmKrediKartGiris";
            Load += FrmKrediKartGiris_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKartlar).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudKesimGunu).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSonOdemeGunu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKartAdi;
        private Label lblKartAdi;
        private ComboBox cmbBanka;
        private Label lblBanka;
        private Label lblSahip;
        private ComboBox cmbSahip;
        private Label label1;
        private Label label2;
        private Button btnEkle;
        private Button btnSil;
        private DataGridView dgvKartlar;
        private NumericUpDown nudKesimGunu;
        private NumericUpDown nudSonOdemeGunu;
    }
}