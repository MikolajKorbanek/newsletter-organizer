using MailKit;
using MimeKit;

namespace NewsletterOrganizer.Domain.Mails;

public interface IMailService
{
    public IMailService WithUser(string username, string password);
    public IMailService FromInbox();
    public IMailService FromSpecialFolder(SpecialFolder folder);
    public IMailService Open();
    public int GetMessageCount();
    public IEnumerable<MimeMessage> GetMessages();

}