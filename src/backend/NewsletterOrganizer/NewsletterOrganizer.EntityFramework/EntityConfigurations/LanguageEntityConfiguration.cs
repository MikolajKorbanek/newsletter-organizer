using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsletterOrganizer.Domain.Settings;

namespace NewsletterOrganizer.EntityFramework.EntityConfigurations;

public class LanguageEntityConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(r => r.LanguageKey);
        
        this.Seed(builder);
    }

    private void Seed(EntityTypeBuilder<Language> builder)
    {
        var list = new List<Language>();
        list.AddRange(new []
        {
            new Language { LanguageKey = "PL", Name = "Polski"},
            new Language { LanguageKey = "EN", Name = "English"},
        });

        builder.HasData(list);
    }
}