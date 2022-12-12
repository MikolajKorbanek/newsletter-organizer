namespace NewsletterOrganizer.Domain.Mails;

public class EmailProvider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProviderProtocolType ProtocolType { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public bool UseSSL { get; set; }
}