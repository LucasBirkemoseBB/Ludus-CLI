using System;
using cli;

// Used to test CLI featuress

namespace test 
{
  public class Test : CLS 
  {
    public override void Initialize()
    {
      
    }

    public override void Draw(ref List<DrawMethod> buffer) 
    {
      
      //                                           X   Y
      CursorPosition position = new CursorPosition(10, 10);
      WriteText("This is a string\0", position, ref buffer);

      CursorPosition pos2 = new CursorPosition(2, 8);
      WriteText("This is ahidushidhis", pos2, ref buffer);

      TextBox box = new TextBox(new CursorPosition(2, 12), 3, 20);
      string[] text = { "Among", "Sussy Baka", "Hello,World" };
      AddBox(box, ref text, ref buffer);

      TextBox box2 = new TextBox(new CursorPosition(25, 12), 3, 20);
      // string[] text = { "Among", "Sussy Baka", "Hello,World" };
      AddBox(box2, ref text, ref buffer);
    }

    public override void Update() 
    {
      
    }
  }
}