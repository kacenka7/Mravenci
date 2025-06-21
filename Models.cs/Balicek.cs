
public class Balicek
{
    public List<Karta> Karty { get; set; } = new List<Karta>();

    public List<Karta> VytvorBalicek()
    {
        //naplnění balíčku

        // Stavební karty
        for (int i = 0; i < 8; i++) Karty.Add(new StavebniKarta("Zeď", 1, "Hrad +3", 0, 3, 0, 0));
        for (int i = 0; i < 7; i++) Karty.Add(new StavebniKarta("Základy", 3, "Hrad +5", 0, 5, 0, 0));
        for (int i = 0; i < 6; i++) Karty.Add(new StavebniKarta("Věž", 7, "Hrad +10", 0, 10, 0, 0));
        for (int i = 0; i < 5; i++) Karty.Add(new StavebniKarta("Pevnost", 15, "Hrad +20", 0, 20, 0, 0));
        for (int i = 0; i < 4; i++) Karty.Add(new StavebniKarta("Babylon", 25, "Hrad +40", 0, 40, 0, 0));
        for (int i = 0; i < 4; i++) Karty.Add(new StavebniKarta("Povoz", 5, "Hrad +10, soupeřův hrad -10", 10, 10, 0, 0));
        for (int i = 0; i < 3; i++) Karty.Add(new StavebniKarta("Stavitel", 3, "Cihly +8", 0, 0, 8, 0));
        for (int i = 0; i < 3; i++) Karty.Add(new StavebniKarta("Demolice", 5, "Cihly soupeře -10", 0, 0, 0, -10));

        // Útočné karty
        for (int i = 0; i < 8; i++) Karty.Add(new UtocnaKarta("Střelec", 1, "Útok 3", 3, 0, 0));
        for (int i = 0; i < 7; i++) Karty.Add(new UtocnaKarta("Rytíř", 3, "Útok 5", 5, 0, 0));
        for (int i = 0; i < 6; i++) Karty.Add(new UtocnaKarta("Četa", 5, "Útok 10", 10, 0, 0));
        for (int i = 0; i < 5; i++) Karty.Add(new UtocnaKarta("Swat", 10, "Útok 10", 10, 10, 0));
        for (int i = 0; i < 4; i++) Karty.Add(new UtocnaKarta("Zloděj", 5, "Nepřítel -10 zbraní, hráč +10 zbraní", 0, 10, 10));
        for (int i = 0; i < 4; i++) Karty.Add(new UtocnaKarta("Drak", 15, "Útok 20", 20, 0, 0));
        for (int i = 0; i < 3; i++) Karty.Add(new UtocnaKarta("Kovář", 3, "Zbraně +8", 0, 8, 0));
        for (int i = 0; i < 3; i++) Karty.Add(new UtocnaKarta("Sabotáž", 5, "Zbraně nepřítele -10", 0, 0, 10));

        // míchání balíčku
        Random rng = new Random();
        int n = Karty.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1); // vybere náhodné číslo od 0 do n (včetně)
            Karta temp = Karty[k]; // uloží kartu na pozici k
            Karty[k] = Karty[n]; // na pozici k dá kartu na konci (pozice n)
            Karty[n] = temp;        // na konec dá kartu původně na pozici k
        }

        return Karty;
    }

    public void ZkontolujKartyVBalicku()
        {
            if (Karty.Count < 1) { VytvorBalicek(); }
        }
}

