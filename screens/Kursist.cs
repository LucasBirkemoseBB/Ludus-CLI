using System;
using cli;
using InputHandler;
using StudentSystem;
using Constants;

namespace KursistSystem
{
    public class Kursist : CLS
    {

        public override void Initialize()
        {
            inputStrings.Add("");
            inputStrings.Add("");
        }

        public override void Draw(ref List<DrawMethod> buffer) 
        {
            Console.Clear();
            buffer.Clear();

            Student student = Consts.studentHandler.currentStudent;

            CursorPosition position = new CursorPosition(20, 10);
            TextBox box = new TextBox(position, 8, 40, false);
            string[] text = {"Kursist", "", $"Navn: {student.navn}", $"Alder: {student.alder}", $"Studieretning: {student.studieRetning}", $"Klasse/år: {student.klassaar}", $"Studienummer: {student.studienummer}", $"Studiemail: {student.studiemail}"};
            AddBox(box, ref text, ref buffer);

            RedoRender = false;
        }

        public override void Update() 
        {
            char key = KeyboardListener.getKeys();
            HandleInput(key);
        }
    }
}