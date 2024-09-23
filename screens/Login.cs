using System;
using cli;
using InputHandler;

namespace LoginSystem
{
    public class Login : CLS
    {

        public override void Initialize()
        {
            inputStrings.Add("");
            inputStrings.Add("");
        }

        public override void Draw(ref List<DrawMethod> buffer) 
        {
            buffer.Clear();
            CursorPosition position = new CursorPosition(6, 6);
            TextBox box = new TextBox(position, 12, 48, false);
            string[] text = {"Login", "","","","","","","","","","",""};
            AddBox(box, ref text, ref buffer);
        
            CursorPosition inputPosition = new CursorPosition(10, 10);
            InputBox ibox = new InputBox(inputPosition, "Username", 1, 40);
            AddInputBox(ibox, inputStrings[0], ref buffer);

            CursorPosition inputPosition2 = new CursorPosition(10, 14);
            InputBox ibox2 = new InputBox(inputPosition2, "Password", 1, 40);
            AddInputBox(ibox2, inputStrings[1], ref buffer);

            // if(keyDown != '\0') text = text + keyDown; 
            RedoRender = false;
        }

        public override void Update() 
        {
            char key = KeyboardListener.getKeys();
            HandleInput(key);
        }
    }
}