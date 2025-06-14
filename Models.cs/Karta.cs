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
}

public class UtocnaKarta: Karta
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

}
