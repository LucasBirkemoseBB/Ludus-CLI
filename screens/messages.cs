using System;
using cli;
using InputHandler;
using ScreenHandler;
using SkemaSystem;
using Constants;
using CreatorSystem;
using MsgSystem;
using StudentSystem;

namespace MessageSystem
{
  public class Messages : CLS
  {
    public Message selectedMessage = new Message(0,0,"");

    public override void Initialize()
    {
      Console.Clear();
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
      if(messages == null) 
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
        string[] msg_text = new string[20];
        
        int l = 0, r = 0;å
        while(r < content.Length) 
        {
          if((r-l)%60 == 0 && r != l) 
          {
            msg_text[l] = content.Substring(l, r);
            r = l;
          }
          r++;
        }

        CursorPosition msg_position = new CursorPosition(50, 2);
        TextBox msg_box = new TextBox(msg_position, 20, 60);
      
        AddBox(msg_box, ref msg_text, ref buffer);
      }

      CursorPosition inputPosition = new CursorPosition(2, 34);
      InputBox ibox = new InputBox(inputPosition, "Read msg nr. ", 1, 40);
      AddInputBox(ibox, inputStrings[0], ref buffer);

      // if(keyDown != '\0') text = text + keyDown; 
      RedoRender = false;
    }

    public override void Update()
    {
      char key = KeyboardListener.getKeys();
      HandleInput(key);

      List<Message> messages = Consts.messageHandler.getRecievedMessages(Consts.studentHandler.currentStudent.studienummer);

      if(key == '\r')
      {
        int.TryParse(inputStrings[0], out int msgIdx);
        selectedMessage = messages[msgIdx];
        RedoRender = true;
      }
    }
  }
}