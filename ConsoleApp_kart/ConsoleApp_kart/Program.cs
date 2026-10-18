using ClassLibrary_kart;

Class_kart oyun = new();
Class_oyuncuIslemler oyuncuIslemleri = new();
bool cikis = false;
while (!cikis)
{
    Console.Clear();
    Console.WriteLine("""
    =========================================
                   KART ÇEKME v2
    =========================================
    """);
    int secim = menu();
    switch (secim)
    {
        case 1:
            oyuncuEkle();
            oyunculariListele();
            break;
        case 2:
            oyunculariListele();
            break;
        case 3:
            oyunculariListele();
            oyuncuGuncelle();
            break;
        case 4:
            oyunculariListele();
            oyna();
            break;
        case 5:
            cikis = true;
            Console.WriteLine("Çıkış yapılıyor...");
            break;
        default:
            Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
            break;
    }
    Console.WriteLine("Devam etmek için bir tuşa basın...");
    Console.ReadKey();
}
int menu()
{
    Console.Write("""
        1. Oyuncu Ekle
        2. Oyuncuları Listele
        3. Oyuncu Güncelle
        4. Oyna
        5. Çıkış
        _________________
        Seçiminiz:
    """);
    string secim = Console.ReadLine();
    return int.TryParse(secim, out int secimInt) ? secimInt : 0;
}
void oyuncuEkle()
{
    Console.Write("Oyuncu Adı: ");
    string ad = Console.ReadLine();
    oyuncuIslemleri.OyuncuEkle(ad);
    Console.WriteLine("Oyuncu başarıyla eklendi!");
}
void oyunculariListele()
{
    List<Class_oyuncu> oyuncular = oyuncuIslemleri.OyunculariListele();
    if (oyuncular.Count == 0)
    {
        Console.WriteLine("Kayıtlı oyuncu bulunmamaktadır.");
        return;
    }
    Console.WriteLine("Kayıtlı Oyuncular:");
    foreach (var oyuncu in oyuncular)
    {
        Console.WriteLine($"{oyuncu.Ad} [Kazanma: {oyuncu.Kazanma} / Kaybetme: {oyuncu.Kaybetme} /Berabere: {oyuncu.Berabere}]");
    }
}
void oyuncuGuncelle()
{
    Console.Write("Güncellemek istediğiniz oyuncunun adını girin: ");
    string eskiAd = Console.ReadLine();
    Console.Write("Yeni Adı: ");
    string yeniAd = Console.ReadLine();
    bool guncellendiMi = oyuncuIslemleri.OyuncuGuncelle(eskiAd, yeniAd);
    if (guncellendiMi)
    {
        Console.WriteLine("Oyuncu başarıyla güncellendi!");
    }
    else
    {
        Console.WriteLine("Oyuncu bulunamadı.");
    }
}
void oyna()
{
    Console.Write("Oynayacak oyuncunun adını girin: ");
    Class_oyuncu secilenOyuncu = oyuncuIslemleri.OyuncuBul(Console.ReadLine());
    if (secilenOyuncu == null)
    {
        Console.WriteLine("Oyuncu bulunamadı.");
        return;
    }
    oyun.oyuncu = secilenOyuncu;
    bool devam=true;
    Console.WriteLine("Açık karta bakın, gizli kart BÜYÜK mü KÜÇÜK mü tahmin edin...\n");
    while (devam)
    {
        Console.WriteLine(oyun.oyuncu.Ad);
        Console.WriteLine(oyun.kartSkorGoster());
        oyun.YeniOyun();
        Console.WriteLine($"Açık kart: {oyun.acikkart}");
        Console.Write("Tahmininiz::(1-BÜYÜK 2-KÜÇÜK)");
        if (oyun.KartSecimGirisi(Console.ReadLine()))
        {
            Console.WriteLine(oyun.KartSecimKontrol());
            Console.Write("Oyuna Devam Etmek İster misiniz (e/h):");
            string cevap = Console.ReadLine();
            devam= cevap.ToLower() != "e" ?  false : true;
        }
        else
        {
            Console.Write("Hatalı Deger Girişi");
        }
    }
    Console.WriteLine("\n--- TOPLU SKOR ---");
    oyunculariListele();
}
