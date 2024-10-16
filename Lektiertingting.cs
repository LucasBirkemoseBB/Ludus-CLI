using System; 
using System.Collections.Generic;
using System.Linq;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace LektierSystem 
{
    // Base struct used to define lektier
    // Defined as struct as its easier to write and read from json file
    public struct Lektier 
    {
        public string Modul { get; set; }
        public string Opgave { get; set; }
        public string Lærer { get; set; }           // Uhhhhhh might be unsafe to have an æ in the variable name, but fuck it
        public string Afleveringsfrist { get; set; }
        public string Elevtimer {   get; set; }
        public string Rettet { get; set; }

        public Lektier(string Modul, string Opgave, string Lærer, string Afleveringsfrist, string Elevtimer, string Rettet)
        {
            this.Modul = Modul;
            this.Opgave = Opgave;
            this.Lærer = Lærer;
            this.Afleveringsfrist = Afleveringsfrist;
            this.Elevtimer = Elevtimer;
            this.Rettet = Rettet;
        }
    }

    public class LektierHandler 
    {
        private List<Lektier> lektierList = new List<Lektier>();
        private const string path = "lektier.json";

        // Self describing
        public void addLektier(Lektier lektier)
        {
            lektierList.Add(lektier);
            saveLektierToFile();
        }

        public void removeLektier(int lektier) 
        {
            lektierList.RemoveAt(lektier);
        }

        public void saveLektierToFile() 
        {
            string json = JsonSerializer.Serialize(lektierList);
            File.WriteAllText(path, json);
        }

        public void loadLektierFromFile() 
        {
            string json = File.ReadAllText(path);
        
            lektierList = JsonSerializer.Deserialize<List<Lektier>>(json);
        }

        public List<Lektier> getLektierList()
        {
            return lektierList;
        }
    }
}
