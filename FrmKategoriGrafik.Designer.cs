namespace MyBudgetUI
{
    partial class FrmKategoriGrafik
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartKategori = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chartKategori).BeginInit();
            SuspendLayout();
            // 
            // chartKategori
            // 
            chartArea1.Name = "ChartArea1";
            chartKategori.ChartAreas.Add(chartArea1);
            chartKategori.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartKategori.Legends.Add(legend1);
            chartKategori.Location = new Point(0, 0);
            chartKategori.Name = "chartKategori";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series1.Legend = "Legend1";
            series1.Name = "Harcamalar";
            chartKategori.Series.Add(series1);
            chartKategori.Size = new Size(798, 624);
            chartKategori.TabIndex = 0;
            chartKategori.Text = "chart1";
            // 
            // FrmKategoriGrafik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 624);
            Controls.Add(chartKategori);
            Name = "FrmKategoriGrafik";
            Text = "FrmKategoriGrafik";
            Load += FrmKategoriGrafik_Load;
            ((System.ComponentModel.ISupportInitialize)chartKategori).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartKategori;
    }
}