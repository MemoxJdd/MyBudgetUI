using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Budget;
using Budget.Entities;

namespace MyBudgetUI
{
    public partial class FrmBankaGiris : Form
    {
        public FrmBankaGiris()
        {
            InitializeComponent();
        }

        private void FrmBankaGiris_Load(object sender, EventArgs e)
        {
            BankalariYukle();
        }
        private void BankalariYukle()
        {
            using (var db = new BudgetContext())
            {
                var bankalar = db.Bankalar
                                 .Select(b => new { b.Id, b.BankaAdi })
                                 .OrderBy(b => b.BankaAdi)
                                 .ToList();
                dgvBankalar.DataSource = bankalar;
                dgvBankalar.Columns["Id"].Visible = false;
                dgvBankalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBankaAdi.Text))
            {
                MessageBox.Show("Lütfen bir banka adı girin.");
                return;
            }

            using (var db = new BudgetContext())
            {
                var banka = new Banka {BankaAdi = txtBankaAdi.Text.Trim() };
                db.Bankalar.Add(banka);
                db.SaveChanges();
            }

            txtBankaAdi.Clear();
            BankalariYukle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvBankalar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.");
                return;
            }

            int seciliId = (int)dgvBankalar.CurrentRow.Cells["Id"].Value;

            using (var db = new BudgetContext())
            {
                var banka = db.Bankalar.FirstOrDefault(b => b.Id == seciliId);
                if (banka != null)
                {
                    db.Bankalar.Remove(banka);
                    db.SaveChanges();
                }
            }

            BankalariYukle();
        }

    }
}
