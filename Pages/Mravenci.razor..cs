using Microsoft.AspNetCore.Components;

namespace Mravenci.Pages
{
    public partial class Mravenci : ComponentBase
    {
        //Hráči
        Hrac cerni = new Hrac("Černí", 20, 5, 5);
        Hrac cerveni = new Hrac("Červení", 20, 5, 5);

        Hrac aktualniHrac;
        Hrac souper;



        //Karty

        List<Karta> balicek = new List<Karta>();

        //naplnění balíčku
        private List<Karta> VytvorBalicek()
        {

            // Stavební karty
            for (int i = 0; i < 8; i++) balicek.Add(new StavebniKarta("Zeď", 1, "Hrad +3", 0, 3, 0, 0));
            for (int i = 0; i < 7; i++) balicek.Add(new StavebniKarta("Základy", 3, "Hrad +5", 0, 5, 0, 0));
            for (int i = 0; i < 6; i++) balicek.Add(new StavebniKarta("Věž", 7, "Hrad +10", 0, 10, 0, 0));
            for (int i = 0; i < 5; i++) balicek.Add(new StavebniKarta("Pevnost", 15, "Hrad +20", 0, 20, 0, 0));
            for (int i = 0; i < 4; i++) balicek.Add(new StavebniKarta("Babylon", 25, "Hrad +40", 0, 40, 0, 0));
            for (int i = 0; i < 4; i++) balicek.Add(new StavebniKarta("Povoz", 5, "Hrad +10, soupeřův hrad -10", 10, 10, 0, 0));
            for (int i = 0; i < 3; i++) balicek.Add(new StavebniKarta("Stavitel", 3, "Cihly +8", 0, 0, 8, 0));
            for (int i = 0; i < 3; i++) balicek.Add(new StavebniKarta("Demolice", 5, "Cihly soupeře -10", 0, 0, 0, -10));

            // Útočné karty
            for (int i = 0; i < 8; i++) balicek.Add(new UtocnaKarta("Střelec", 1, "Útok 3", 3, 0, 0));
            for (int i = 0; i < 7; i++) balicek.Add(new UtocnaKarta("Rytíř", 3, "Útok 5", 5, 0, 0));
            for (int i = 0; i < 6; i++) balicek.Add(new UtocnaKarta("Četa", 5, "Útok 10", 10, 0, 0));
            for (int i = 0; i < 5; i++) balicek.Add(new UtocnaKarta("Swat", 10, "Útok 10", 10, 10, 0));
            for (int i = 0; i < 4; i++) balicek.Add(new UtocnaKarta("Zloděj", 5, "Nepřítel -10 zbraní, hráč +10 zbraní", 0, 10, 10));
            for (int i = 0; i < 4; i++) balicek.Add(new UtocnaKarta("Drak", 15, "Útok 20", 20, 0, 0));
            for (int i = 0; i < 3; i++) balicek.Add(new UtocnaKarta("Kovář", 3, "Zbraně +8", 0, 8, 0));
            for (int i = 0; i < 3; i++) balicek.Add(new UtocnaKarta("Sabotáž", 5, "Zbraně nepřítele -10", 0, 0, 10));

            // míchání balíčku
            Random rng = new Random();
            int n = balicek.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1); // vybere náhodné číslo od 0 do n (včetně)
                Karta temp = balicek[k]; // uloží kartu na pozici k
                balicek[k] = balicek[n]; // na pozici k dá kartu na konci (pozice n)
                balicek[n] = temp;        // na konec dá kartu původně na pozici k
            }

            return balicek;
        }

        // Karty v ruce hráče
        List<Karta> rukaCerni = new List<Karta>();
        List<Karta> rukaCerveni = new List<Karta>();

        List<Karta> aktualniRuka;

        private List<Karta> RozdejKarty(List<Karta> ruka, List<Karta> balicek)
        {
            while (ruka.Count < 5)
            {
                Karta karta = balicek[balicek.Count - 1];
                ruka.Add(karta);
                balicek.RemoveAt(balicek.Count - 1);
            }

            return ruka;
        }

        public void ZkontolujKartyVBalicku()
        {
            if (balicek.Count < 1) { VytvorBalicek(); }
        }

        public void PrepniAktualniRuku()
        {
            aktualniRuka = aktualniHrac == cerni ? rukaCerni : rukaCerveni;
        }

        public void OdeberKartuZRuky(int index)
        {
            aktualniRuka.RemoveAt(index);
        }

        public void DoberKartuZBalicku()
        {
            Karta novaKarta = balicek[balicek.Count - 1];
            balicek.RemoveAt(balicek.Count - 1);
            aktualniRuka.Add(novaKarta);
        }

        public void PrepniHrace()
        {
            aktualniHrac = aktualniHrac == cerni ? cerveni : cerni;
            souper = aktualniHrac == cerni ? cerveni : cerni;
            aktualniRuka = aktualniHrac == cerni ? rukaCerni : rukaCerveni;
        }

        bool hraSkoncila = false;
        string vytezstvi = "";
        public void VyhodnotHru()
        {
            if (cerni.Hrad > 99 || cerveni.Hrad < 1)
            {
                vytezstvi = "Vyhráli Černí mravenci!";
                hraSkoncila = true;
            }
            else if (cerveni.Hrad > 99 || cerni.Hrad < 1)
            {
                vytezstvi = "Vyhráli Červení mravenci!";
                hraSkoncila = true;
            }

        }

        //Zahrání karty

        public void HracZahralKartu(int index)
        {
            //ukončení hry
            if (hraSkoncila) { return; }

            // ošetření, aby nedošli karty v balíčku
            ZkontolujKartyVBalicku();

            // přepínání aktuálních karet
            PrepniAktualniRuku();

            // připsání surovin
            aktualniHrac.PridejSuroviny();

            //zahrání karty
            Karta karta = aktualniRuka[index];
            karta.ZahrajKartu(aktualniHrac, souper);

            //odebrání odehrané karty z ruky
            OdeberKartuZRuky(index);

            //dobrání nové karty z balíčku
            DoberKartuZBalicku();

            // přepnutí hráče
            PrepniHrace();

            // vyhodnocení hry
            VyhodnotHru();

            StateHasChanged();

        }

        public void ZahodKartu(int index)
        {
            //ukončení hry
            if (hraSkoncila) { return; }

            // ošetření, aby nedošli karty v balíčku
            ZkontolujKartyVBalicku();

            // přepínání aktuálních karet
            PrepniAktualniRuku();

            // připsání surovin
            aktualniHrac.PridejSuroviny();

            //odebrání  karty z ruky
            OdeberKartuZRuky(index);

            //dobrání nové karty z balíčku
            DoberKartuZBalicku();

            // přepnutí hráče
            PrepniHrace();

            // vyhodnocení hry
            VyhodnotHru();

            StateHasChanged();

        }


        //Postup hry
        protected override void OnInitialized()
        {
            VytvorBalicek();
            RozdejKarty(rukaCerni, balicek);
            RozdejKarty(rukaCerveni, balicek);
            aktualniHrac = cerni;
            souper = cerveni;
            aktualniRuka = rukaCerni;

        }


    }
}

