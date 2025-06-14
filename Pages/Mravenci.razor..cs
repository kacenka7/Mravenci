using Microsoft.AspNetCore.Components;

namespace Mravenci.Pages
{
    public partial class Mravenci
    {
        //Hráči
        Hrac cerni = new Hrac("Černí", 20, 5, 5);
        Hrac cerveni = new Hrac("Červení", 20, 5, 5);

        //Karty

        StavebniKarta zed = new StavebniKarta("Zeď", 1, "Hrad +3", 0, 3, 0, 0);
        StavebniKarta zaklady = new StavebniKarta("Základy", 3, "Hrad +5", 0, 5, 0, 0);
        StavebniKarta vez = new StavebniKarta("Věž", 7, "Hrad +10", 0, 10, 0, 0);
        StavebniKarta pevnost = new StavebniKarta("Pevnost", 15, "Hrad +20", 0, 20, 0, 0);
        StavebniKarta babylon = new StavebniKarta("Babylon", 25, "Hrad +40", 0, 40, 0, 0);
        StavebniKarta povoz = new StavebniKarta("Povoz", 10, "Hrad +10", 10, 10, 0, 0);
        StavebniKarta stavitel = new StavebniKarta("Stavitel", 3, "Cihly +8", 0, 0, 8, 0);
        StavebniKarta demolice = new StavebniKarta("Demolice", 5, "Cihly soupeře -10", 0, 0, 0, -10);
        
        UtocnaKarta strelec = new UtocnaKarta("Střelec", 1, "Útok 3", 3, 0, 0);
        UtocnaKarta rytir = new UtocnaKarta("Rytíř", 3, "Útok 5", 5, 0, 0);
        UtocnaKarta ceta = new UtocnaKarta("Četa", 5, "Útok 10", 10, 0, 0);
        UtocnaKarta swat = new UtocnaKarta("Swat", 10, "Útok 10, Hrad +10", 10, 0, 0); // Hrad +10 řeš v logice
        UtocnaKarta zlodej = new UtocnaKarta("Zloděj", 10, "Nepřítel -10 zbraní, hráč +10 zbraní", 0, 10, -10);
        UtocnaKarta drak = new UtocnaKarta("Drak", 15, "Útok 20", 20, 0, 0);
        UtocnaKarta kovar = new UtocnaKarta("Kovář", 3, "Zbraně +8", 0, 8, 0);
        UtocnaKarta sabotaz = new UtocnaKarta("Sabotáž", 5, "Zbraně nepřítele -10", 0, 0, -10);


    }
}

