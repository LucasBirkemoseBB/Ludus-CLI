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
      CursorPosition position2 = new CursorPosition(2, 3);
      WriteText("This is another string\0", position2, ref buffer);
 

      //                                           X   Y
      CursorPosition position = new CursorPosition(10, 10);
      WriteText("This is a string\0", position, ref buffer);

    }
  }
}