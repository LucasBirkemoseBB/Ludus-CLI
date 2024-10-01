using system; 

public class Lektier 
{
    public string Modul { get; set; }
    public string Opgave { get; set; }
    public string Lærer { get; set; }
    public string Afleveringsfrist { get; set; }
    public string Elevtimer {   get; set; }
    public string Rettet { get; set; }

    public Lektier(string Modul, string Opgave, string Lærer, string Afleveringsfrist, string Elevtimer, string Rettet)
    {
        Modul = Modul;
        Opgave = Opgave;
        Lærer = Lærer;
        Afleveringsfrist = Afleveringsfrist;
        Elevtimer = Elevtimer;
        Rettet = Rettet;
    }
}