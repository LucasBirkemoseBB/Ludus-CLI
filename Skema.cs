using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace SkemaKlasseSystem
{
  public readonly struct Klasse 
  {
    public readonly int teacherId{get;}
    public readonly int location{get;}
    public readonly int length{get;}
    public readonly int day{get;}
    public readonly string room{get;}
    public readonly string klasse{get;}
    public readonly string label{get;}

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
    public List<Klasse> klasser = new List<Klasse>();

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
  }
}