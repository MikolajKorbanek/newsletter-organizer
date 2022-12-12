using System.ComponentModel.DataAnnotations.Schema;
using NewsletterOrganizer.Domain.Settings;

namespace NewsletterOrganizer.Domain.Newsletters;

public class NewsletterWord
{
    public int Id { get; set; }
    [ForeignKey("Language")]
    public string LanguageKey { get; set; }
    public string Word { get; set; }

    public virtual Language Language { get; set; }
}