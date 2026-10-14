using ClassLibrary_kart;

Class_kart oyun = new();
bool devam=true;
Console.WriteLine("""
    =========================================
                   KART ÇEKME v1
    =========================================
    """);
Console.WriteLine("Açık karta bakın, gizli kart BÜYÜK mü KÜÇÜK mü tahmin edin...\n");
oyun.ad = "Burak";
oyun.soyad = "eker";
while (devam)
{
   Console.WriteLine(oyun.oyuncu);
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
