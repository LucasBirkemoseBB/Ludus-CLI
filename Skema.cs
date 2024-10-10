using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace SkemaSystem
{
  // En skole klasse
  public struct Klasse 
  {
    public int teacherId{get;set;}
    public int location{get;set;}
    public int length{get;set;}
    public int day{get;set;}
    public string room{get;set;}
    public string klasse{get;set;}
    public string label{get;set;}

    public Klasse(int teacherId, int location, int length, int day, string room, string klasse, string label)
    {
      this.teacherId = teacherId;
      this.location = location;
      this.length = length;
      this.day = day;
      this.room = room;
      this.klasse = klasse;
      this.label = label;
    }
  };

  public class SkemaHandler 
  {
    private List<Klasse> klasser = new List<Klasse>();

    public void addKlasse(Klasse klasse)
    {
      klasser.Add(klasse);
    }

    public void removeKlasse(int identifier)
    {
      klasser.RemoveAt(identifier);
    }

    public void saveToFile(string path)
    {
      string json = JsonSerializer.Serialize(klasser);
      File.WriteAllText(path, json);
    }

    public void loadFromFile(string path)
    {
      string json = File.ReadAllText(path);

      klasser = JsonSerializer.Deserialize<List<Klasse>>(json);
    }

    public List<Klasse> getKlasser() 
    {
      return klasser;
    }

    public Klasse getKlasse(int idx) 
    {
      return klasser[idx];
    }
  }
}
