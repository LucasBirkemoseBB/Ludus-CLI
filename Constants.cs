using System;
using MsgSystem;
using StudentSystem;
using LektierHandler;

namespace Constants 
{
  public class Consts 
  {
    public static StudentHandler studentHandler = new StudentHandler();
    public static MessageHandler messageHandler = new MessageHandler();
    public static LektierWorker lektierHandler = new LektierWorker();
  }
}