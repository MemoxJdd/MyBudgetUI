namespace MyBudgetUI
{
    partial class FrmAylikOzet
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
            cmbAy = new ComboBox();
            label1 = new Label();
            btnGoster = new Button();
            dgvOzet = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOzet).BeginInit();
            SuspendLayout();
            // 
            // cmbAy
            // 
            cmbAy.FormattingEnabled = true;
            cmbAy.Location = new Point(108, 26);
            cmbAy.Name = "cmbAy";
            cmbAy.Size = new Size(216, 28);
            cmbAy.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 34);
            label1.Name = "label1";
            label1.Size = new Size(26, 20);
            label1.TabIndex = 1;
            label1.Text = "Ay";
            // 
            // btnGoster
            // 
            btnGoster.Location = new Point(419, 21);
            btnGoster.Name = "btnGoster";
            btnGoster.Size = new Size(94, 29);
            btnGoster.TabIndex = 2;
            btnGoster.Text = "Göster";
            btnGoster.UseVisualStyleBackColor = true;
            btnGoster.Click += btnGoster_Click;
            // 
            // dgvOzet
            // 
            dgvOzet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOzet.Location = new Point(24, 71);
            dgvOzet.Name = "dgvOzet";
            dgvOzet.RowHeadersWidth = 51;
            dgvOzet.Size = new Size(751, 675);
            dgvOzet.TabIndex = 3;
            // 
            // FrmAylikOzet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 785);
            Controls.Add(dgvOzet);
            Controls.Add(btnGoster);
            Controls.Add(label1);
            Controls.Add(cmbAy);
            Name = "FrmAylikOzet";
            Text = "FrmAylikOzet";
            Load += FrmAylikOzet_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOzet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAy;
        private Label label1;
        private Button btnGoster;
        private DataGridView dgvOzet;
    }
}