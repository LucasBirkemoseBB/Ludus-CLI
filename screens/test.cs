using System;
using cli;

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


    }
  }
}