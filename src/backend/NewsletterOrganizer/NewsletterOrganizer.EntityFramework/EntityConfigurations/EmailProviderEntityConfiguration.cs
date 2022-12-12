using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsletterOrganizer.Domain.Mails;
using NewsletterOrganizer.Domain.Settings;

namespace NewsletterOrganizer.EntityFramework.EntityConfigurations;

public class EmailProviderEntityConfiguration : IEntityTypeConfiguration<EmailProvider>
{
    public void Configure(EntityTypeBuilder<EmailProvider> builder)
    {
        builder.HasKey(r => r.Id);
        
        this.Seed(builder);
    }

    private void Seed(EntityTypeBuilder<EmailProvider> builder)
    {
        var list = new List<EmailProvider>();
        list.AddRange(new []
        {
            new EmailProvider() {Name = "Gmail", Host = "imap.gmail.com", Port = 993, UseSSL = true, ProtocolType = ProviderProtocolType.IMAP, Id = 1},
            new EmailProvider() {Name = "Yahoo", Host = "imap.mail.yahoo.com", Port = 993, UseSSL = true, ProtocolType = ProviderProtocolType.IMAP, Id = 2},
            new EmailProvider() {Name = "Outlook - IMAP", Host = "outlook.office365.com", Port = 993, UseSSL = true, ProtocolType = ProviderProtocolType.IMAP, Id = 3},
            new EmailProvider() {Name = "Outlook - POP3", Host = "outlook.office365.com", Port = 995, UseSSL = true, ProtocolType = ProviderProtocolType.POP3, Id = 4},
            new EmailProvider() {Name = "iCloud", Host = "imap.mail.me.com", Port = 993, UseSSL = true, ProtocolType = ProviderProtocolType.IMAP, Id = 5}
        });

        builder.HasData(list);
    }
}