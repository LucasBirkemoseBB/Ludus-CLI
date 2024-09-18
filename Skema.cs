using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace SkemaSystem
{
  public readonly struct Klasse 
  {
    private readonly int teacherId{get;}
    private readonly int location{get;}
    private readonly int length{get;}
    private readonly string room{get;}
    private readonly string klasse{get;}
    private readonly string label{get;}

    public Klasse(int teacherId, int location, int length, string room, string klasse, string label)
    {
      this.teacherId = teacherId;
      this.location = location;
      this.length = length;
      this.room = room;
      this.klasse = klasse;
      this.label = label;
    }
  };

  public class Skema 
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