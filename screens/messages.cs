using System;
using cli;
using InputHandler;
using ScreenHandler;
using SkemaSystem;
using Constants;
using CreatorSystem;
using StudentSystem;

namespace MessageSystem
{
  public class Messages : CLS
  {
    public Message selectedMessage = new Message(0,0,"");
    public Student messaging = new Student();

    public override void Initialize()
    {
      Console.Clear();
      Consts.messageHandler.loadFromServer();
      inputStrings.Add("");
      inputStrings.Add("");
    }

    public override void Draw(ref List<DrawMethod> buffer)
    {
      buffer.Clear();
      CursorPosition position = new CursorPosition(0, 0);
      TextBox box = new TextBox(position, 32, 48, false);
      string[] text = new string[32]; 
      text[0] = "Messages";
      for(int i = 0; i < 31; ++i) text[i + 1] = "";
      AddBox(box, ref text, ref buffer);

      List<Message> messages = Consts.messageHandler.getRecievedMessages(Consts.studentHandler.currentStudent.studienummer);
      if(messages == null || messages.Count() == 0) 
      {
        CursorPosition nomsgspos = new CursorPosition(10, 10);
        TextBox sad_box = new TextBox(nomsgspos, 3, 30, true);
        string[] sad_text = {"", "You have no new messages :(", ""};
        AddBox(sad_box, ref sad_text, ref buffer);
      }
      else 
      {
        for(int i = 0; i < messages.Count(); ++i) 
        {
          Message msg = messages[i];
          Student ?student = Consts.studentHandler.studenter.Find(x => x.studienummer == msg.sender);
          if(student == null) continue;

          CursorPosition msg_position = new CursorPosition(2, 2 + 4 * i);
          TextBox msg_box = new TextBox(msg_position, 2, 40);

          string content = msg.content;
          if(content.Length >= 40) content = content.Substring(0, 37) + "...";

          string[] msg_text = {"From: " + student.navn, content};

          AddBox(msg_box, ref msg_text, ref buffer);
        }
      }

      if(selectedMessage.sender != 0)
      {
        string content = selectedMessage.content;
        double length = content.Length;
        double lines = (content.Length/60d);
        string[] msg_text = new string[(int)Math.Ceiling(lines)];
        
        if(content.Length >= 60) 
        {
          int count = 0;
          for(int i = 0; i < content.Length; i+=60, count++)
          {
            msg_text[count] = content.Substring(i, content.Length-i>=60?60:content.Length-i);
          }
        }

        CursorPosition msg_position = new CursorPosition(50, 2);
        TextBox msg_box = new TextBox(msg_position, content.Length/60+1, 60);
      
        AddBox(msg_box, ref msg_text, ref buffer);
      }

      if(messaging.navn != null) 
      {
        CursorPosition msg_position = new CursorPosition(50, 2);
        InputBox msg_box = new InputBox(msg_position, "Message content: ", 6, 60);
        AddInputBox(msg_box, inputStrings[2], ref buffer);
      }

      CursorPosition inputPosition = new CursorPosition(0, 34);
      InputBox ibox = new InputBox(inputPosition, "Read msg nr. ", 1, 16);
      AddInputBox(ibox, inputStrings[0], ref buffer);
      
      CursorPosition inputPosition2 = new CursorPosition(18, 34);
      InputBox ibox2 = new InputBox(inputPosition2, "Send message to:", 1, 18);
      AddInputBox(ibox2, inputStrings[1], ref buffer);
      
      RedoRender = false;
    }

    public override void Update()
    {
      char key = KeyboardListener.getKeys();
      HandleInput(key);

      List<Message> messages = Consts.messageHandler.getRecievedMessages(Consts.studentHandler.currentStudent.studienummer);

      if(key == '\r')
      {
        switch(selectedStringIndex) 
        {
          case 0:
            if(int.TryParse(inputStrings[0], out int msgIdx))
              selectedMessage = messages[msgIdx];
            else 
              if(inputStrings[0].Equals("back"))
                Screens.currentScreen = new Skema();
            RedoRender = true;
            if(inputStrings.Count() > 2)
            {
              inputStrings.RemoveAt(2);
            }
            messaging = new Student();
            break;
          case 1:
            RedoRender = true;
            
            if(inputStrings.Count() < 3)
              inputStrings.Add("");

            selectedMessage = new Message(0,0,"");
            if(int.TryParse(inputStrings[1], out int userId)) 
            {
              messaging = Consts.studentHandler.studenter.Find(x => x.studienummer == userId);
              selectedStringIndex = 2;
              break;
            }
            messaging = Consts.studentHandler.studenter.Find(x => x.navn.Equals(inputStrings[1]));
            selectedStringIndex = 2;
            break;
          case 2:
            Consts.messageHandler.sendMessage(Consts.studentHandler.currentStudent.studienummer, messaging.studienummer, inputStrings[2]);
            messaging = new Student();
            selectedStringIndex = 0;
            break;
        }
      }
    }
  }
}