using System;
using cli;
using InputHandler;
using SkemaKlasseSystem;
using ScreenHandler;
using LoginSystem;
using MessageSystem;
using KursistSystem;

namespace SkemaSystem
{
  public class Skema : CLS
  {
    private SkemaHandler skemaHandler = new SkemaHandler();
    public override void Initialize()
    {
      Console.Clear();
      skemaHandler.loadFromFile("skema1.json");
      inputStrings.Add("");
    }

    public override void Draw(ref List<DrawMethod> buffer) 
    {
      buffer.Clear();
      CursorPosition position = new CursorPosition(0, 0);
      TextBox box = new TextBox(position, 35, 80, true);
      string[] text = {"Skema", "Controls: [logout, kursist, meddelelser(msg), lektier]", "","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","", ""};
      AddBox(box, ref text, ref buffer);

      for(int i = 0; i < skemaHandler.getKlasser().Count; ++i) 
      {
        Klasse klasse = skemaHandler.getKlasse(i);
        
        CursorPosition initPos = new CursorPosition(3 + klasse.day * 22, 3 + klasse.location * 4);

        string[] txt = { klasse.label, "Tid: " + klasse.length };
        TextBox kla = new TextBox(initPos, 2, 20, false);
        AddBox(kla, ref txt, ref buffer);
      }

      CursorPosition inputPos = new CursorPosition(3, 37);
      InputBox input = new InputBox(inputPos, "Next location?", 1,40);

      // if(inputStrings.Count == 0) inputStrings.Add("");
      AddInputBox(input, inputStrings[0], ref buffer);

      // if(keyDown != '\0') text = text + keyDown; 
      RedoRender = false;
    }

    public override void Update() 
    {
      char key = KeyboardListener.getKeys();
      HandleInput(key);

      if(key == '\r')
      {
        switch(inputStrings[0])
        {
        case "logout":
          Screens.currentScreen = new Login();
          break;
        case "kursist":
          Screens.currentScreen = new Kursist();
          break;
        case "meddelelser":
        case "msg":
          Screens.currentScreen = new Messages();
          break;
        case "lektier":
          break;
        };
      }

      // Console.WriteLine(skemaHandler.getKlasse(0).location);
      // Console.WriteLine(skemaHandler.getKlasse(1).location);

      // Console.WriteLine(skemaHandler.klasser.Count);
    }
  }
}