namespace ClassLibrary_kart
{

    public class Class_kart
    {
        Random rnd = new();
        int _acikkart, _gizlikart, ksecim = 0;
        public Class_oyuncu oyuncu { get; set; }
        public int acikkart { get{ return _acikkart; } }
        public void YeniOyun()
        {
            _acikkart = rnd.Next(1, 11);
            _gizlikart = rnd.Next(1, 11);
            ksecim = 0;
        }
        public bool KartSecimGirisi(string deger)
        {
            bool kontrol = Int32.TryParse(deger, out ksecim);
            if (kontrol && (ksecim < 1 || ksecim > 2)) kontrol = false;
            return kontrol;
        }
        public string KartSecimKontrol()
        {
            string sonuc = "";
            if (_gizlikart == _acikkart) { sonuc = "BERABERE";oyuncu.Berabere++; }
            else
            {
                if (ksecim == 1 && _gizlikart > _acikkart || ksecim == 2 && _gizlikart < _acikkart) { sonuc = "KAZANDINIZ"; oyuncu.Kazanma++; }
                else { sonuc = "KAYBETTİNİZ";oyuncu.Kaybetme++; }
            }
            return $"Gizli kart: {_gizlikart}  {sonuc}";
        }
        public string kartSkorGoster() {
            string skormetni = $"[Kazanma: {oyuncu.Kazanma} / Kaybetme: {oyuncu.Kaybetme} /Berabere: {oyuncu.Berabere}]";
            return skormetni;
        }
    }
    public class Class_oyuncu
    {
        public string Ad { get; set; }
        public int Kazanma { get; set; }
        public int Kaybetme { get; set; }
        public int Berabere { get; set; }
        public Class_oyuncu(string ad)
        {
            Ad = ad;
        }
    }
    public class Class_oyuncuIslemler
    {
        private List<Class_oyuncu> oyuncular = new();
        public void OyuncuEkle(string ad)
        {
            Class_oyuncu yeniOyuncu = new Class_oyuncu(ad);
            oyuncular.Add(yeniOyuncu);
        }
        public List<Class_oyuncu> OyunculariListele()
        {
            return oyuncular.OrderBy(o => o.Ad).ToList();
        }
        public Class_oyuncu OyuncuBul(string ad)
        {
            return oyuncular.FirstOrDefault(o => o.Ad == ad);
        }
        public bool OyuncuGuncelle(string eskiAd, string yeniAd)
        {
            bool guncellendiMi = false;
            var oyuncu = oyuncular.FirstOrDefault(o => o.Ad == eskiAd);
            if (oyuncu != null)
            {
                oyuncu.Ad = yeniAd;
                guncellendiMi = true;
            }
            return guncellendiMi;
        }
    }
}
