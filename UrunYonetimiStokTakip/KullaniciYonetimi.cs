using BL;
using Entities;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UrunYonetimiStokTakip
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        KullaniciManager manager = new KullaniciManager(); 
        void Yukle()
        {
            dgvKullanicilar.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            lblId.Text = string.Empty;
            txtAdi.Text = string.Empty;
            txtSoyadi.Text = string.Empty;
            txtKullaniciAdi.Text = string.Empty;
            txtSifre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cbDurum.Checked = false;
        }
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc =manager.Add(new Kullanici
                {
                    Adi=txtAdi.Text,
                    Soyadi=txtSoyadi.Text,
                    KullaniciAdi=txtKullaniciAdi.Text,
                    Sifre=txtSifre.Text,
                    Email=txtEmail.Text,
                    Aktif=cbDurum.Checked,
                });
                if (sonuc>0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt başarıyla eklenmiştir");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu eklenemedi");
            }
          
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Update(new Kullanici
                {
                    Id=int.Parse(lblId.Text),
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    KullaniciAdi = txtKullaniciAdi.Text,
                    Sifre = txtSifre.Text,
                    Email = txtEmail.Text,
                    Aktif = cbDurum.Checked,
                });
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt başarıyla güncellenmiştir");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu güncellenemedi");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text=="0")
                {
                    MessageBox.Show("Lütfen bir kullanıcı seçiniz");
                }
                else
                {
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc>0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Kayıt başarıyla silinmiştir");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bir hata oluştu");
            }
           
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text =dgvKullanicilar.CurrentRow.Cells[0].Value.ToString();
            txtKullaniciAdi.Text = dgvKullanicilar.CurrentRow.Cells[1].Value.ToString();
            txtSifre.Text = dgvKullanicilar.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dgvKullanicilar.CurrentRow.Cells[3].Value.ToString();
            txtAdi.Text = dgvKullanicilar.CurrentRow.Cells[4].Value.ToString();
            txtSoyadi.Text = dgvKullanicilar.CurrentRow.Cells[5].Value.ToString();
            cbDurum.Checked = Convert.ToBoolean(dgvKullanicilar.CurrentRow.Cells[6].Value);
        }
    }
}
