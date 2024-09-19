using System;
using System.Runtime.InteropServices;

namespace InputHandler
{

  public class KeyboardListener
  {
    // Fordi det er for irriterende at få input in c#
    [DllImport("keyboard.so", EntryPoint="getKeys")]
    public static extern char getKeys();
  };

  public class KeyboardInput 
  {


    public void Initialize() 
    {
      /*
      while(true) 
      {
        
        char keyDown = KeyboardListener.getKeys();
      
        // if(keyDown != '\0') Console.WriteLine(keyDown);
      }*/


    }
  };
}