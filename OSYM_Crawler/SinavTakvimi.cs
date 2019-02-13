using System;
using System.Collections.Generic;

namespace OSYM_Crawler
{
    public class SinavTakvimi
    {
        public string Baslik { get; set; }
        public int Donem { get; set; }
        public IList<Kolon> Kolonlar { get; set; }
        private IList<Sinav> sinavlar;
        public IList<Sinav> Sinavlar {
            get
            {
                return sinavlar;
            }
            set
            {
                sinavlar = value;
                if (sinavlar[0].Tarihi.HasValue)
                {
                    Donem = sinavlar[0].Tarihi.Value.Year;
                }
            }
        }
        public string Uyarilar { get; set; }
    }
    public class Sinav
    {
        public string Adi { get; set; }
        public string KisaAdi { get; set; }
        public string Aciklama { get; set; }
        public string Baglanti { get; set; }
        public IList<Basvuru> Basvuru { get; set; }
        public IList<Basvuru> GecBasvuru { get; set; }
        public DateTime? Tarihi { get; set; }
        public DateTime? SonucAciklamaTarihi { get; set; }
    }
    public class Basvuru
    {
        public string Turu { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
    }
    public class Kolon
    {
        public string Adi { get; set; }
        public string Etiketi { get; set; }
    }
}
