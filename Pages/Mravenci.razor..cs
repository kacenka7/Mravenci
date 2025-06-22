using Microsoft.AspNetCore.Components;
namespace Mravenci.Pages
{
    public partial class Mravenci : ComponentBase
    {
        bool zobrazZmenuSurovin = false;
        //Hráči
        Hrac cerni = new Hrac("Černí", 20, 5, 5);
        Hrac cerveni = new Hrac("Červení", 20, 5, 5);

        Hrac aktualniHrac = null!;
        Hrac souper = null!;

        //Balíček
        Balicek balicek = new Balicek();

        // Karty v ruce hráče
        KartyvRuce rukaCerni = new KartyvRuce();
        KartyvRuce rukaCerveni = new KartyvRuce();
        KartyvRuce aktualniRuka = new KartyvRuce();

        Karta? posledniZahranaKarta = null;

        public void PrepniAktualniRuku()
        {
            aktualniRuka = aktualniHrac == cerni ? rukaCerni : rukaCerveni;
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

        public async void HracZahralKartu(int index)
        {
            //ukončení hry
            if (hraSkoncila) { return; }

            // ošetření, aby nedošli karty v balíčku
            balicek.ZkontolujKartyVBalicku();

            //zahrání karty
            posledniZahranaKarta = aktualniRuka.Ruka[index];
            Karta karta = aktualniRuka.Ruka[index];

            zobrazZmenuSurovin = true;
            StateHasChanged();

            karta.ZahrajKartu(aktualniHrac, souper);

            //odebrání odehrané karty z ruky
            aktualniRuka.OdeberKartuZRuky(index);

            //dobrání nové karty z balíčku
            aktualniRuka.DoberKartuZBalicku(balicek);

            // vyhodnocení hry
            VyhodnotHru();

            // přepnutí hráče
            PrepniHrace();

            // připsání surovin
            aktualniHrac.PridejSuroviny();

            StateHasChanged();

            await Task.Delay(1000);
            zobrazZmenuSurovin = false;
            StateHasChanged();

        }

        public void ZahodKartu(int index)
        {
            //ukončení hry
            if (hraSkoncila) { return; }

            // ošetření, aby nedošli karty v balíčku
            balicek.ZkontolujKartyVBalicku();

            // přepínání aktuálních karet
            PrepniAktualniRuku();

            //odebrání  karty z ruky
            aktualniRuka.OdeberKartuZRuky(index);

            //dobrání nové karty z balíčku
            aktualniRuka.DoberKartuZBalicku(balicek);

            // vyhodnocení hry
            VyhodnotHru();

            // přepnutí hráče
            PrepniHrace();

            // přepínání aktuálních karet
            PrepniAktualniRuku();

            // připsání surovin
            int kolo = 0;
            if (kolo < 1)
            {
                souper.PridejSuroviny();
                kolo += 1;
            }

            StateHasChanged();

        }

        //Postup hry
        protected override void OnInitialized()
        {
            aktualniHrac = cerni;
            souper = cerveni;
            aktualniRuka = rukaCerni;
            balicek.VytvorBalicek();
            rukaCerni.RozdejKarty(balicek.Karty);
            rukaCerveni.RozdejKarty(balicek.Karty);
        }

    }
}

