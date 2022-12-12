using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsletterOrganizer.Domain.Newsletters;
using NewsletterOrganizer.Domain.Settings;

namespace NewsletterOrganizer.EntityFramework.EntityConfigurations;

public class NewsletterWordEntityConfiguration : IEntityTypeConfiguration<NewsletterWord>
{
    public void Configure(EntityTypeBuilder<NewsletterWord> builder)
    {
        builder.HasKey(r => r.Id);
        
        this.Seed(builder);
    }

    private void Seed(EntityTypeBuilder<NewsletterWord> builder)
    {
        var list = new List<NewsletterWord>();
        list.AddRange(new []
        {
            new NewsletterWord() { LanguageKey = "PL", Word = "Anuluj Subskrybcję", Id = 1},
            new NewsletterWord() { LanguageKey = "PL", Word = "Wypisz", Id = 2},
            new NewsletterWord() { LanguageKey = "PL", Word = "Newsletter", Id = 3},
            new NewsletterWord() { LanguageKey = "PL", Word = "Otrzymałeś tę wiadomość", Id = 4},
            new NewsletterWord() { LanguageKey = "EN", Word = "Unsubscribe", Id = 5},
            new NewsletterWord() { LanguageKey = "EN", Word = "Newsletter", Id = 6},
            new NewsletterWord() { LanguageKey = "EN", Word = "Subscription", Id = 7}
        });
        builder.HasData(list);
    }
}