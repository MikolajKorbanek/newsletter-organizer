using MailKit;
using MailKit.Net.Pop3;
using MimeKit;

namespace NewsletterOrganizer.Domain.Mails;

public class Pop3MailService
{
    private readonly Pop3Client _client;

    public Pop3MailService(string host, int port, bool useSSl)
    {
        _client = new Pop3Client();
        _client.Connect(host, port, useSSl);
    }

    public Pop3MailService WithUser(string username, string password)
    {
        _client.Authenticate(username, password);
        return this;
    }

    public int GetMessageCount()
    {
        return _client.Count;
    }

    public IEnumerable<MimeMessage> GetMessages()
    {
        var messages = new List<MimeMessage>();
        var messagesCount = GetMessageCount();

        for(var i = 0; i < messagesCount; i++)
        {
            var message = _client.GetMessage(i);

            messages.Add(message);
        };

        return messages;    
    }
}