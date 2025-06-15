public abstract class Karta
{
    public string Nazev { get; set; }
    public int Cena { get; set; }
    public string Popis { get; set; }
    public int Utok { get; set; }



    public Karta(string nazev, int cena, string popis, int utok)
    {
        Nazev = nazev;
        Cena = cena;
        Popis = popis;
        Utok = utok;
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
        int stavba,
        int mojeCihli,
        int cihlySoupere
    ) : base(nazev, cena, popis, utok)
    {
        Stavba = stavba;
        MojeCihli = mojeCihli;
        CihlySoupere = cihlySoupere;
    }
    public override void ZahrajKartu(Hrac hrac, Hrac souper)
    {
        hrac.Hrad += Stavba;
        hrac.PocetCihel -= Cena;
        if (hrac.PocetCihel < 0)
        {
            hrac.PocetCihel = 0;
        }
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
        if (aktualniHrac.PocetCihel < Cena)
        {
            return false;
        }
        else
        {
            return true;
        }
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
        int mojeZbrane,
        int zbraneSoupere
    ) : base(nazev, cena, popis, utok)
    {
        MojeZbrane = mojeZbrane;
        ZbraneSoupere = zbraneSoupere;
    }

    public override void ZahrajKartu(Hrac hrac, Hrac souper)
    {

        hrac.PocetZbrani -= Cena;
        if (hrac.PocetZbrani < 0)
        {
            hrac.PocetZbrani = 0;
        }
        hrac.PocetZbrani += MojeZbrane;
        souper.Hrad -= Utok;
        souper.PocetZbrani -= ZbraneSoupere;
        if (souper.PocetZbrani < 0)
        {
            souper.PocetZbrani = 0;
        }
    }

    public override bool JeKartaHratelna(Hrac aktualniHrac)
    {
        if (aktualniHrac.PocetZbrani < Cena)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

