using System;
using cli;
using InputHandler;
using ScreenHandler;
using SkemaSystem;
using Constants;
using LoginSystem;

namespace CreatorSystem
{
  public class StudentCreator : CLS
  {

    public override void Initialize()
    {
      Console.Clear();
      inputStrings.Add("");
      inputStrings.Add("");
      inputStrings.Add("");
      inputStrings.Add("");
      inputStrings.Add("");
    }

    public override void Draw(ref List<DrawMethod> buffer)
    {
      buffer.Clear();
      CursorPosition position = new CursorPosition(6, 6);
      TextBox box = new TextBox(position, 22, 48, false);
      string[] text = { "Student creator", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
      AddBox(box, ref text, ref buffer);

      // NAVN
      CursorPosition inputPosition = new CursorPosition(8, 8);
      InputBox ibox = new InputBox(inputPosition, "Navn", 1, 40);
      AddInputBox(ibox, inputStrings[0], ref buffer);

      // ALDER
      CursorPosition inputPosition2 = new CursorPosition(8, 12);
      InputBox ibox2 = new InputBox(inputPosition2, "Alder", 1, 40);
      AddInputBox(ibox2, inputStrings[1], ref buffer);

      // STUDIERETNING
      CursorPosition inputPosition3 = new CursorPosition(8, 16);
      InputBox ibox3 = new InputBox(inputPosition3, "Studie retning", 1, 40);
      AddInputBox(ibox3, inputStrings[2], ref buffer);

      // KLASSEAAR
      CursorPosition inputPosition4 = new CursorPosition(8, 20);
      InputBox ibox4 = new InputBox(inputPosition4, "Klasse år", 1, 40);
      AddInputBox(ibox4, inputStrings[3], ref buffer);

      // STUDIENUMMER
      CursorPosition inputPosition5 = new CursorPosition(8, 24);
      InputBox ibox5 = new InputBox(inputPosition5, "Studie nummer", 1, 40);
      AddInputBox(ibox5, inputStrings[4], ref buffer);

      RedoRender = false;
    }

    public override void Update()
    {
      char key = KeyboardListener.getKeys();
      HandleInput(key);

      if(key == '\r') 
      {
        string navn = inputStrings[0];
        int.TryParse(inputStrings[1], out int alder);
        string studieretning = inputStrings[2];
        string klasseaar = inputStrings[3];
        int.TryParse(inputStrings[4], out int studienummer);
        string mail = studienummer.ToString() + "@edu.rybners.dk";

        Consts.studentHandler.addStudent(new StudentSystem.Student(navn, alder, studieretning, klasseaar, studienummer, mail));
        Screens.currentScreen = new Login();

      }
    }
  }
}