using System;
using cli;
using InputHandler;

namespace LoginSystem
{
    public class Login : CLS
    {
        public string txt = "";

        public override void Initialize()
        {
            
        }

        public override void Draw(ref List<DrawMethod> buffer) 
        {
            CursorPosition position = new CursorPosition(0, 0);
            TextBox box = new TextBox(position, 3, 40, true);
            string[] text = {"", "Login and KYS", ""};
            AddBox(box, ref text, ref buffer);
        
            CursorPosition inputPosition = new CursorPosition(10, 10);
            InputBox ibox = new InputBox(inputPosition, 1, 40);
            AddInputBox(ibox, ref txt, ref buffer);

            // if(keyDown != '\0') text = text + keyDown; 
        }

        public override void Update() 
        {
            
        }
    }
}