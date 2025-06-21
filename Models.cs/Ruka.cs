public class KartyvRuce
{
    public List<Karta> Ruka { get; set; } = new();

    // Rozdání karet z balíčku, dokud jich není 5
    public List<Karta> RozdejKarty(List<Karta> balicek)
    {
        while (Ruka.Count < 5 && balicek.Count > 0)
        {
            Karta karta = balicek[^1]; // syntaktický cukr: balicek[balicek.Count - 1]
            Ruka.Add(karta);
            balicek.RemoveAt(balicek.Count - 1);
        }

        return Ruka;
    }

    // Odebere kartu z ruky na zadaném indexu (kontrola rozsahu)
    public void OdeberKartuZRuky(int index)
    {
        if (index >= 0 && index < Ruka.Count)
        {
            Ruka.RemoveAt(index);
        }
    }

    // Přidá kartu z balíčku do ruky, pokud balíček není prázdný
    public void DoberKartuZBalicku(Balicek balicek)
    {
        if (balicek.Karty.Count > 0)
        {
            Karta novaKarta = balicek.Karty[^1];
            balicek.Karty.RemoveAt(balicek.Karty.Count - 1);
            Ruka.Add(novaKarta);
        }
    }
}