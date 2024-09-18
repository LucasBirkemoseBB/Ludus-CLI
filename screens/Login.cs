using System;
using cli;

namespace LoginSystem
{
    public class Login : CLS
    {
        public override void Initialize()
        {
            
        }

        public override void Draw(ref List<DrawMethod> buffer) 
        {
            CursorPosition position = new CursorPosition(0, 0);
            TextBox box = new TextBox(position, 3, 40, true);
            string[] text = {"", "Login and KYS", ""};
            AddBox(box, ref text, ref buffer);
        }
    }
}