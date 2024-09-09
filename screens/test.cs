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
      CursorPosition position = new CursorPosition(10, 0);
      WriteText("This is a string", position, ref buffer);
    }
  }
}