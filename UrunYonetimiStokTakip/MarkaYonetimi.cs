using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entities;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class MarkaYonetimi : Form
    {
        public MarkaYonetimi()
        {
            InitializeComponent();
        }
        MarkaManager manager = new MarkaManager(); 
        void Yukle()
        {
            dgvMarkalar.DataSource = manager.GetAll();
        }
        private void MarkaYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Temizle()
        {
            lblId.Text = string.Empty;
            txtMarkaAdi.Text = string.Empty;
            rchMarkaAciklamasi.Text = string.Empty;
            lblEklenmeTarihi.Text = string.Empty;
            cbDurum.Checked = false;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            int islemsonucu = manager.Add(
                new Entities.Marka {
                    MarkaAdi = txtMarkaAdi.Text,
                    Aciklamasi=rchMarkaAciklamasi.Text,
                    Aktif=cbDurum.Checked,
                    EklenmeTarihi=DateTime.Now,
             });
            if (islemsonucu > 0)
            {
                Temizle();
                Yukle();
                MessageBox.Show("Marka Eklenmiştir");
            }
            else
            {
                MessageBox.Show("Kayıt Eklenemedi!!!");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            if (id > 0)
            {
                var islemsonucu = manager.Update(new Marka
                {
                    Id = id,
                    MarkaAdi = txtMarkaAdi.Text,
                    Aciklamasi = rchMarkaAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = Convert.ToDateTime(lblEklenmeTarihi.Text),
                });
                if (islemsonucu > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Marka Güncellenmiştir");
                }
                else
                {
                    MessageBox.Show("Güncellenmedi!!!");
                }
            }
            else MessageBox.Show("Lütfen listeden bir kayıt seçiniz");

        }

        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dgvMarkalar.CurrentRow.Cells[0].Value.ToString();
            txtMarkaAdi.Text = dgvMarkalar.CurrentRow.Cells[1].Value.ToString();
            rchMarkaAciklamasi.Text= dgvMarkalar.CurrentRow.Cells[2].Value.ToString();
            lblEklenmeTarihi.Text = dgvMarkalar.CurrentRow.Cells[3].Value.ToString();
            cbDurum.Checked = Convert.ToBoolean(dgvMarkalar.CurrentRow.Cells[4].Value);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            if (id > 0)
            {
                int islemsonucu =manager.Delete(id);
                if (islemsonucu > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Marka Silinmiştir");
                }
                else
                {
                    MessageBox.Show("Silinemedi!!!");
                }
            }
            else MessageBox.Show("Lütfen listeden bir kayıt seçiniz");
        }
    }
}
