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
}