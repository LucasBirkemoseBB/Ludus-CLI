using System;
using System.Runtime.InteropServices;

namespace InputHandler
{
  public class KeyboardListener
  {
    // Fordi det er for irriterende at få input in c#... spørg ik
    // Imports the c function "getKeys" from keyboard.so which was compiled from keyboard.c
    [DllImport("keyboard.so", EntryPoint="getKeys")]
    public static extern char getKeys();
  };
}