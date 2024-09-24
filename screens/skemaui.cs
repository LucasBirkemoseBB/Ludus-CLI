using System;
using cli;
using InputHandler;
using SkemaKlasseSystem;

namespace SkemaSystem
{
  public class Skema : CLS
  {

    private SkemaHandler skemaHandler = new SkemaHandler();

    public override void Initialize()
    {
      skemaHandler.loadFromFile("skema1.json");
    }

    public override void Draw(ref List<DrawMethod> buffer) 
    {
      buffer.Clear();
      CursorPosition position = new CursorPosition(0, 0);
      TextBox box = new TextBox(position, 30, 80, false);
      string[] text = {"Skema", "", "","","","","","","","","","","","","","","","","","","","","","","","","","","", ""};
      AddBox(box, ref text, ref buffer);

      for(int i = 0; i < skemaHandler.klasser.Count; ++i) 
      {
        Klasse klasse = skemaHandler.klasser[i];
        
        CursorPosition initPos = new CursorPosition(3 + klasse.day*22, 3 + klasse.location * 4);
        
        string[] txt = { "klasse.label", "Tid: ", "" };
        TextBox kla = new TextBox(initPos, 2, 20, false);
        AddBox(kla, ref txt, ref buffer);
      }

      // if(keyDown != '\0') text = text + keyDown; 
      RedoRender = false;
    }

    public override void Update() 
    {
      char key = KeyboardListener.getKeys();
      HandleInput(key);
      // Console.WriteLine(skemaHandler.klasser.Count);
    }
  }
}