using System;
using MessageSystem;
using StudentSystem;
using LektierSystem;

namespace Constants 
{
  // Contains global variables which should remain the same for the programs entire lifetime
  public class Consts 
  { 
    public static StudentHandler studentHandler = new StudentHandler();
    public static MessageHandler messageHandler = new MessageHandler();
    public static LektierHandler lektierHandler = new LektierHandler();
  }
}