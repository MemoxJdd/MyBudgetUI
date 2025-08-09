using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Budget;
using Budget.Entities;

using Microsoft.EntityFrameworkCore;

namespace MyBudgetUI
{
    public partial class FrmKisiDetay : Form
    {
        private int _kisiId;
        private string _donem;

      

        public FrmKisiDetay(int kisiId, string donem)
        {
            InitializeComponent();
            _kisiId = kisiId;
            _donem = donem;
        }

        private void FrmKisiDetay_Load(object sender, EventArgs e)
        {
            int secilenYil = int.Parse(_donem.Split('-')[0]);
            int secilenAy = int.Parse(_donem.Split('-')[1]);

            using (var db = new BudgetContext())
            {
                // 🟢 Kişi adı etikete yazılıyor
                var kisi = db.Kisiler.FirstOrDefault(k => k.Id == _kisiId);
                if (kisi != null)
                {
                    lblAd.Text = kisi.Ad;
                }

                var harcamalar = db.Taksitler
                    .Include(t => t.Harcama)
                    .AsEnumerable() // Burada EF'den çıkıyoruz, LINQ to Objects başlıyor
                    .Where(t => t.Harcama.KisiId == _kisiId &&
                                DateTime.Parse(t.Ay).Year == secilenYil &&
                                DateTime.Parse(t.Ay).Month == secilenAy)
                    .GroupBy(t => t.HarcamaId)
                    .Select(g => new
                    {g.First().Tarih,
                        Aciklama = g.First().Harcama.Aciklama,
                        Tutar = g.Sum(x => x.Tutar)
                    })
                    .ToList();




                dgvHarcamaDetay.DataSource = harcamalar;
                dgvHarcamaDetay.Columns["Tutar"].DefaultCellStyle.Format = "C2";
                dgvHarcamaDetay.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHarcamaDetay.Columns["Aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // 🔽 Ödemeler
                var odenenler = db.Odemeler
                    .Where(o => o.KisiId == _kisiId &&
                                o.Tarih.Year == secilenYil &&
                                o.Tarih.Month == secilenAy)
                    .Select(o => new
                    {
                        o.Tarih,
                        o.Aciklama,
                        o.Tutar
                    })
                    .ToList();

                dgvOdemeDetay.DataSource = odenenler;
                dgvOdemeDetay.Columns["Tutar"].DefaultCellStyle.Format = "C2";
                dgvOdemeDetay.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOdemeDetay.Columns["Aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // 🔽 Toplamlar
                decimal toplamHarcama = harcamalar.Sum(x => x.Tutar);
                decimal toplamOdeme = odenenler.Sum(x => x.Tutar);
                decimal netBakiye = toplamOdeme - toplamHarcama;

                lblToplamHarcama.Text = $"Toplam Harcama : {toplamHarcama:C2}";
                lblToplamOdeme.Text = $"Toplam Ödeme : {toplamOdeme:C2}";
                lblNetBakiye.Text = $"Net Bakiye : {netBakiye:C2}";

                if (netBakiye < 0)
                {
                    lblNetBakiye.Text = $"Net Bakiye : {Math.Abs(netBakiye):C2}";
                    lblNetBakiye.ForeColor = Color.Red;
                }
                else
                {
                    lblNetBakiye.Text = $"Net Bakiye : {netBakiye:C2}";
                    lblNetBakiye.ForeColor = Color.Green;
                }

            }
        }



    }
}
