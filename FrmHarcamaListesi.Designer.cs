namespace MyBudgetUI
{
    partial class FrmHarcamaListesi
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
            Button btnGuncelle;
            Button btnSil;
            dgvHarcamalar = new DataGridView();
            btnGuncelle = new Button();
            btnSil = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHarcamalar).BeginInit();
            SuspendLayout();
            // 
            // btnGuncelle
            // 
            btnGuncelle.Font = new Font("Segoe UI", 14F);
            btnGuncelle.Location = new Point(25, 632);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(200, 50);
            btnGuncelle.TabIndex = 1;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Font = new Font("Segoe UI", 14F);
            btnSil.Location = new Point(247, 632);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(200, 50);
            btnSil.TabIndex = 2;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // dgvHarcamalar
            // 
            dgvHarcamalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHarcamalar.Location = new Point(12, 43);
            dgvHarcamalar.Name = "dgvHarcamalar";
            dgvHarcamalar.RowHeadersWidth = 51;
            dgvHarcamalar.Size = new Size(1038, 567);
            dgvHarcamalar.TabIndex = 0;
            dgvHarcamalar.CellClick += dataGridViewHarcamalar_CellClick;
            // 
            // FrmHarcamaListesi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 737);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(dgvHarcamalar);
            Name = "FrmHarcamaListesi";
            Text = "FrmHarcamaListesi";
            Load += FrmHarcamaListesi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHarcamalar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHarcamalar;
        
         
        


        private int seciliHarcamaId = -1;

        private void dataGridViewHarcamalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHarcamalar.Rows[e.RowIndex];
                seciliHarcamaId = Convert.ToInt32(row.Cells["Id"].Value);
                //txtAciklama.Text = row.Cells["Aciklama"].Value.ToString();
              
            }
        }
       // private int seciliHarcamaId = -1;

      



    }


}