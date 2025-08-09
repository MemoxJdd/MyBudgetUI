using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Budget;

using DocumentFormat.OpenXml.Bibliography;
namespace MyBudgetUI
{
    public partial class FrmKategoriGrafik : Form
    {
        private readonly List<KategoriRaporDto> _veriler;
        private readonly string _donem;

        public FrmKategoriGrafik(List<KategoriRaporDto> veriler, string donem)
        {
            InitializeComponent();
            _veriler = veriler;
            _donem = donem;
        }      
               

        public List<KategoriRaporDto> Liste { get; }
        public List<KategoriRaporDto> Liste1 { get; }
        public List<KategoriRaporDto> Liste2 { get; }

        private void FrmKategoriGrafik_Load(object sender, EventArgs e)
        {
            chartKategori.Series.Clear();
            chartKategori.Titles.Clear();

            chartKategori.ChartAreas[0].AxisX.Interval = 1;
            chartKategori.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartKategori.ChartAreas[0].AxisY.LabelStyle.Format = "c";
            chartKategori.ChartAreas[0].BackColor = Color.White;

            chartKategori.Titles.Add(new System.Windows.Forms.DataVisualization.Charting.Title($"Kategori Bazlı Harcamalar - {_donem}", Docking.Top,
                new Font("Segoe UI", 12, FontStyle.Bold), Color.Black));

            var seri = new Series("Harcamalar")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.Black,
                LabelFormat = "c",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Color = Color.SteelBlue
            };

            foreach (var item in _veriler)
            {
                var dp = new DataPoint
                {
                    AxisLabel = item.Kategori,
                    YValues = new[] { (double)item.ToplamTutar },
                    Label = item.ToplamTutar.ToString("C2"),
                    ToolTip = $"{item.Kategori} - {item.ToplamTutar:C2}"
                };
                seri.Points.Add(dp);
            }

            chartKategori.Series.Add(seri);
        }


        public class KategoriRaporDto
        {
            public string Kategori { get; set; }
            public decimal ToplamTutar { get; set; }
        }

    }
}



