using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        UrunManager um = new UrunManager();
        void Yukle()
        {
            dgvUrunler.DataSource = um.GetAll();
        }
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = um.Add(new Urun
                {
                    UrunAdi=txtUrunAdi.Text,
                    UrunFiyat=decimal.Parse(txtUrunFiyati.Text),
                    Aciklama=rchUrunAciklamasi.Text,
                    Aktif=cbDurum.Checked,
                    EklenmeTarihi=DateTime.Now,
                    Iskonto=int.Parse(txtIskonto.Text),
                    Kdv=int.Parse(txtKdv.Text),
                    StokMiktari=int.Parse(txtStokMiktari.Text),
                    ToplamFiyat=int.Parse(txtUrunFiyati.Text),
                
                    
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
