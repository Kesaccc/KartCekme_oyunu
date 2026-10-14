namespace ClassLibrary_kart
{

    public class Class_kart
    {
        Random rnd = new();
        int _acikkart, _gizlikart, ksecim = 0;
        private int kazanma, kaybetme, berabere = 0;
        public string ad { private get; set; }
        public string soyad { private get; set{ value = value.ToUpper(); } }
        public string oyuncu { get{ return $"{ad} {soyad}"; } }
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
            if (_gizlikart == _acikkart) { sonuc = "BERABERE";berabere++; }
            else
            {
                if (ksecim == 1 && _gizlikart > _acikkart || ksecim == 2 && _gizlikart < _acikkart) { sonuc = "KAZANDINIZ"; kazanma++; }
                else { sonuc = "KAYBETTİNİZ";kaybetme++; }
            }
            return $"Gizli kart: {_gizlikart}  {sonuc}";
        }
        public string kartSkorGoster() {
            string skormetni = $"[Kazanma: {kazanma} / Kaybetme: {kaybetme} /Berabere: {berabere}]";
            return skormetni;
        }
    }
}
