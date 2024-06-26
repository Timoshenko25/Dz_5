using System;
using System.Collections.Generic;

public class Message
{
    public string Content { get; set; }
    public bool IsRead { get; set; }
}

public class MessageList
{
    private List<Message> messages;

    public MessageList()
    {
        messages = new List<Message>();
    }

    public void AddMessage(string content)
    {
        messages.Add(new Message { Content = content, IsRead = false });
    }

    public List<Message> GetUnreadMessages()
    {
        return messages.FindAll(message => !message.IsRead);
    }

   
    public void MarkAsRead(int index)
    {
        if (index >= 0 && index < messages.Count)
        {
            messages[index].IsRead = true;
        }
        else
        {
            Console.WriteLine("Недопустимый индекс сообщения");
        }
    }
}

class Program
{
    static void Main()
    {
        MessageList messageList = new MessageList();
        messageList.AddMessage("Привет, как дела?");
        messageList.AddMessage("Получил мое письмо?");
        messageList.AddMessage("Важное уведомление");

        List<Message> unreadMessages = messageList.GetUnreadMessages();
        Console.WriteLine("Непрочитанные сообщения:");
        foreach (var message in unreadMessages)
        {
            Console.WriteLine(message.Content);
        }

        messageList.MarkAsRead(0);

        unreadMessages = messageList.GetUnreadMessages();
        Console.WriteLine("\nНепрочитанные сообщения после отметки первого как прочитанного:");
        foreach (var message in unreadMessages)
        {
            Console.WriteLine(message.Content);
        }
    }
}
