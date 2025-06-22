public abstract class Karta
{
    public string Nazev { get; set; }
    public int Cena { get; set; }
    public string Popis { get; set; }
    public int Utok { get; set; }
    public bool ZobrazZmenuSurovin { get; set; }

    public Karta(string nazev, int cena, string popis, int utok, bool zmenaSurovin)
    {
        Nazev = nazev;
        Cena = cena;
        Popis = popis;
        Utok = utok;
        ZobrazZmenuSurovin = zmenaSurovin;
    }

    public abstract void ZahrajKartu(Hrac hrac, Hrac souper);
    public abstract bool JeKartaHratelna(Hrac aktualniHrac);
}

public class StavebniKarta : Karta
{
    public int Stavba { get; set; }
    public int MojeCihli { get; set; }
    public int CihlySoupere { get; set; }

    public StavebniKarta(
        string nazev,
        int cena,
        string popis,
        int utok,
        bool zmenaSurovin, // zobrazeni změny
        int stavba,
        int mojeCihli,
        int cihlySoupere
    ) : base(nazev, cena, popis, utok, zmenaSurovin)
    {
        Stavba = stavba;
        MojeCihli = mojeCihli;
        CihlySoupere = cihlySoupere;
    }
    public override void ZahrajKartu(Hrac hrac, Hrac souper)
    {
        hrac.Hrad += Stavba;
        hrac.PocetCihel -= Cena;
        hrac.PocetCihel += MojeCihli;
        souper.Hrad -= Utok;
        souper.PocetCihel -= CihlySoupere;
        if (souper.PocetCihel < 0)
        {
            souper.PocetCihel = 0;
        }

    }

    public override bool JeKartaHratelna(Hrac aktualniHrac)
    {
        return aktualniHrac.PocetCihel >= Cena;
    }

}

public class UtocnaKarta : Karta
{
    public int MojeZbrane { get; set; }
    public int ZbraneSoupere { get; set; }

    public UtocnaKarta(
        string nazev,
        int cena,
        string popis,
        int utok,
         bool zmenaSurovin,
        int mojeZbrane,
        int zbraneSoupere
    ) : base(nazev, cena, popis, utok, zmenaSurovin)
    {
        MojeZbrane = mojeZbrane;
        ZbraneSoupere = zbraneSoupere;
    }

    public event Action OnStateChanged;
    public async override void ZahrajKartu(Hrac hrac, Hrac souper)
    {
        hrac.PocetZbrani -= Cena;
        hrac.PocetZbrani += MojeZbrane;
        souper.Hrad -= Utok;
        souper.PocetZbrani -= ZbraneSoupere;
        if (souper.PocetZbrani < 0)
        {
            souper.PocetZbrani = 0;
        }

        ZobrazZmenuSurovin = true;
        await Task.Delay(500); // Po 1 sekundě skryj
        ZobrazZmenuSurovin = false;
        OnStateChanged?.Invoke();
    }

    public override bool JeKartaHratelna(Hrac aktualniHrac)
    {
        return aktualniHrac.PocetZbrani >= Cena;
    }
}

