using MailKit;
using MimeKit;

namespace NewsletterOrganizer.Domain.Mail;

public interface IMailService
{
    public ImapMailService WithUser(string username, string password);
    public ImapMailService FromInbox();
    public ImapMailService FromSpecialFolder(SpecialFolder folder);
    public ImapMailService Open();
    public int GetMessageCount();
    public IEnumerable<MimeMessage> GetMessages();

}