using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MsgSystem
{
  public struct Message
  {
    public int sender { get; set; }
    public int recipient { get; set; }
    public string content { get; set; }

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
    private HttpClient messageClient = new HttpClient();

    public MessageHandler()
    {
      // if (!File.Exists(path)) return;
      // string json = File.ReadAllText(path);
      // messages = JsonSerializer.Deserialize<List<Message>>(json);
      loadFromServer();
    }

    public void sendMessage(int sender, int recipient, string content)
    {
      var message = new Message(sender, recipient, content);
      messages.Add(message);
      sendToServer(message);
      // string json = JsonSerializer.Serialize(messages);
      // File.WriteAllText(msgs_path, json);
    }

    public List<Message> getRecievedMessages(int recipient)
    {
      if (messages.Count() == 0) return null;
      return messages.FindAll((x) => x.recipient == recipient);
    }

    public async void loadFromServer()
    {
      using HttpResponseMessage response = await messageClient.GetAsync("http://localhost:4201/");
      response.EnsureSuccessStatusCode();
      var responseBody = await response.Content.ReadAsStreamAsync();

      messages = JsonSerializer.Deserialize<List<Message>>(responseBody);
    }

    public async void sendToServer(Message message)
    {
      var content = JsonContent.Create(message);
      var post = await messageClient.PostAsync("http://localhost:4201/", content);
      
    }
  }
}