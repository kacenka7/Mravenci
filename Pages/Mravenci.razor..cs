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

        //Balíček
        Balicek balicek = new Balicek();

 
        // Karty v ruce hráče
        KartyvRuce rukaCerni = new KartyvRuce();
        KartyvRuce rukaCerveni = new KartyvRuce();
        KartyvRuce aktualniRuka = new KartyvRuce ();

        
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

        public void HracZahralKartu(int index)
        {
            //ukončení hry
            if (hraSkoncila) { return; }

            // ošetření, aby nedošli karty v balíčku
            balicek.ZkontolujKartyVBalicku();

            // přepínání aktuálních karet
            PrepniAktualniRuku();

            // připsání surovin
            aktualniHrac.PridejSuroviny();

            //zahrání karty
            Karta karta = aktualniRuka.Ruka[index];
            karta.ZahrajKartu(aktualniHrac, souper);

            //odebrání odehrané karty z ruky
            aktualniRuka.OdeberKartuZRuky(index);

            //dobrání nové karty z balíčku
            aktualniRuka.DoberKartuZBalicku(balicek);

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
            balicek.ZkontolujKartyVBalicku();

            // přepínání aktuálních karet
            PrepniAktualniRuku();

            // připsání surovin
            aktualniHrac.PridejSuroviny();

            //odebrání  karty z ruky
            aktualniRuka.OdeberKartuZRuky(index);

            //dobrání nové karty z balíčku
            aktualniRuka.DoberKartuZBalicku(balicek);

            // přepnutí hráče
            PrepniHrace();

            // vyhodnocení hry
            VyhodnotHru();

            StateHasChanged();

        }


        //Postup hry
        protected override void OnInitialized()
        {
            balicek.VytvorBalicek();
            rukaCerni.RozdejKarty(balicek.Karty);
            rukaCerveni.RozdejKarty(balicek.Karty);
            aktualniHrac = cerni;
            souper = cerveni;
            aktualniRuka = rukaCerni;

        }


    }
}

