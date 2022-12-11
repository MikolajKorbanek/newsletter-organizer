namespace NewsletterOrganizer.Domain.Users;

public class EmailAccount
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string EmailAddress { get; set; }

    public virtual User User { get; set; }
}