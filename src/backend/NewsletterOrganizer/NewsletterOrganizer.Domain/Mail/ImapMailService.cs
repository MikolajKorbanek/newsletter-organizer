using MailKit;
using MailKit.Net.Imap;
using MimeKit;

namespace NewsletterOrganizer.Domain.Mail;

public sealed class ImapMailService : IMailService, IDisposable
{
    private readonly ImapClient _client;
    private IMailFolder _mailFolder;

    public ImapMailService(string host, int port, bool useSSl)
    {
        _client = new ImapClient();
        _client.Connect(host, port, useSSl);
    }

    public ImapMailService WithUser(string username, string password)
    {
        //TODO REMOVE nxytblzssniqzjdv
        _client.Authenticate(username, password);
        return this;
    }

    public ImapMailService FromInbox()
    {
        _mailFolder = _client.Inbox;
        return this;
    }

    public ImapMailService FromSpecialFolder(SpecialFolder folder)
    {
        _mailFolder = _client.GetFolder(folder);
        return this;
    }

    public ImapMailService Open()
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