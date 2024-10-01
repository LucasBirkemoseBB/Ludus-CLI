using System;
using cli;
using InputHandler;

namespace LektierSystem
{
    public class Lektier : CLS
    {

        public override void Initialize()
        {

        }

        public override void Draw(ref List<DrawMethod> buffer) 
        {
            buffer.Clear();
            CursorPosition position = new CursorPosition(1, 1);
            TextBox box = new TextBox(position, 5, 61, false);
            string[] text = {"Lektier", "", "", "", ""};
            AddBox(box, ref text, ref buffer);

            CursorPosition position2 = new CursorPosition(2, 2);
            TextBox box2 = new TextBox(position2, 1, 59, true);
            string[] text2 = {"Modul, Opgave, Lærer, Afleveringsfrist, Elevtimer, Rettet"};
            AddBox(box2, ref text2, ref buffer);

            RedoRender = false;
        }

        public override void Update() 
        {
            char key = KeyboardListener.getKeys();
            HandleInput(key);
        }
    }
}