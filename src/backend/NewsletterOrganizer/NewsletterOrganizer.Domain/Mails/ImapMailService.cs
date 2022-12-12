using System.Diagnostics;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;

namespace NewsletterOrganizer.Domain.Mails;

public sealed class ImapMailService : IMailService, IDisposable
{
    private readonly ImapClient _client;
    private IMailFolder? _mailFolder;

    public ImapMailService(string host, int port, bool useSSl)
    {
        _client = new ImapClient();
        _client.Connect(host, port, useSSl);
    }

    public IMailService WithUser(string username, string password)
    {
        _client.Authenticate(username, password);
        return this;
    }

    public IMailService FromInbox()
    {
        _mailFolder = _client.Inbox;
        return this;
    }

    public IMailService FromSpecialFolder(SpecialFolder folder)
    {
        _mailFolder = _client.GetFolder(folder);
        return this;
    }

    public IMailService Open()
    {
        _mailFolder.Open(FolderAccess.ReadOnly);
        return this;
    }

    public int GetMessageCount()
    {
        return _mailFolder.Count;
    }

    public IEnumerable<MimeMessage> GetMessages()
    {
        var messages = new List<MimeMessage>();
        var messagesCount = GetMessageCount();

        for(var i = 0; i < messagesCount; i++)
        {
            var message = _mailFolder.GetMessage(i);

            messages.Add(message);
        };

        return messages;
    }

    public void Dispose()
    {
        _client.Disconnect(true);
        _client.Dispose();
    }
}