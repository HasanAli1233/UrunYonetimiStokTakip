using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        KategoriManager manager = new KategoriManager();  
        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            lblId.Text = string.Empty;  
            txtKategoriAdi.Text = string.Empty;
            rchKategoriAciklamasi.Text = string.Empty;
            label5.Text = string.Empty;
            cbDurum.Checked = false;
        }
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(new Kategori
                {
                    KategoriAdi = txtKategoriAdi.Text,
                    Aciklamasi = rchKategoriAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = DateTime.Now,
                });
                if (sonuc > 0)
                {
                    Yukle();
                    MessageBox.Show("Kayıt Eklenmiştir");
                    Temizle();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata oluştu kayıt eklenemedi!n\\",hata.Message.ToString());
            } 
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Update(new Kategori
                {
                    Id = int.Parse(lblId.Text),
                    KategoriAdi = txtKategoriAdi.Text,
                    Aciklamasi = rchKategoriAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = Convert.ToDateTime(label5.Text),
                });
                if (sonuc > 0)
                {
                    Yukle();
                    MessageBox.Show("Kayıt Güncellendi");
                    Temizle();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata oluştu kayıt güncellenemedi !n\\", hata.Message.ToString());
            }
        }
        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvKategoriler.CurrentRow.Cells[0].Value.ToString();
                txtKategoriAdi.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString();
                rchKategoriAciklamasi.Text = dgvKategoriler.CurrentRow.Cells[2].Value.ToString();
                label5.Text = dgvKategoriler.CurrentRow.Cells[3].Value.ToString();
                cbDurum.Checked = Convert.ToBoolean(dgvKategoriler.CurrentRow.Cells[4].Value);
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata oluştu!n\\", hata.Message.ToString());
            }
           
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text=="0")
                {
                    MessageBox.Show("Lütfen Listeden bir kategori seçiniz");
                }
                else
                {
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt başarıyla silinmiştir");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu silinemedi");
            }
            
        }
    }
}
