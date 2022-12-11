using System.ComponentModel.DataAnnotations;
using NewsletterOrganizer.Domain.Newsletters;

namespace NewsletterOrganizer.Domain.Settings;

public class Language
{
    [Key]
    public string LanguageKey { get; set; }
    public string Name { get; set; }

    public virtual IEnumerable<NewsletterWord> NewsletterWords { get; set; }
}