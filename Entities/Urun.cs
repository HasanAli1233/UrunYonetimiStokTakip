﻿using System;

namespace Entities
{
    public class Urun : IEntity
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int MarkaId { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
        public decimal UrunFiyat { get; set; }
        public int Kdv { get; set; }
        public int StokMiktari { get; set; }
        public int Iskonto { get; set; }
        public  decimal ToplamFiyat { get; set; }
    }
}
