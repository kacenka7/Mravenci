public class Hrac
{
    public string Jmeno { get; set; }
    public int Hrad { get; set; }
    public int PocetCihel { get; set; }
    public int PocetZbrani { get; set; }

    public Hrac(string jmeno, int hrad, int cihly, int zbrane)
    {
        Jmeno = jmeno;
        Hrad = hrad;
        PocetCihel = cihly;
        PocetZbrani = zbrane;
    }
}



