namespace NewsletterOrganizer.Domain.Users;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public virtual  IEnumerable<EmailAccount> EmailAccounts { get; set; }
}