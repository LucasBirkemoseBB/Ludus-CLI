using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MsgSystem
{
  public struct Message 
  {
    public int sender{get;set;}
    public int recipient{get;set;}
    public string content{get;set;}

    public Message(int sender, int recipient, string content) 
    {
      this.sender = sender;
      this.recipient = recipient;
      this.content = content;
    }

  };

  public class MessageHandler 
  {
    private List<Message> messages = new List<Message>();
    private string msgs_path;

    public MessageHandler(string path) 
    {
      msgs_path = path;

      if(!File.Exists(path)) return;
      string json = File.ReadAllText(path);
      messages = JsonSerializer.Deserialize<List<Message>>(json);
    }

    public void sendMessage(int sender, int recipient, string content) 
    {
      messages.Add(new Message(sender, recipient, content));

      string json = JsonSerializer.Serialize(messages);
      File.WriteAllText(msgs_path, json);
    }

    public List<Message> getRecievedMessages(int recipient)
    {
      if(messages.Count() == 0) return null;
      return messages.FindAll((x) => x.recipient == recipient);
    }
  }
}