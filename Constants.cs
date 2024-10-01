using System;
using MsgSystem;
using StudentSystem;

namespace Constants 
{
  public class Consts 
  {
    public static StudentHandler studentHandler = new StudentHandler();
    public static MessageHandler messageHandler = new MessageHandler("messages.json");
  }
}