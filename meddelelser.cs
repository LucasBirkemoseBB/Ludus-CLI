using System;
using System.Text.Json;
using StudentSystem;

namespace MsgSystem
{
  public class Message 
  {
    public int sender, recipient;
    public string content;

    public Message(int sender, int recipient, string content) 
    {
      this.sender = sender;
      this.recipient = recipient;
      this.content = content;
    }

    public Message() 
    {
      
    }

    public string getContent() 
    {
      return content;
    }

    public int getSender()
    {
      return sender;
    }

    public int getRecipient() 
    {
      return recipient;
    }
  }

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
      return messages.FindAll((x) => x.getRecipient() == recipient);
    }
  }
}