using Microsoft.EntityFrameworkCore;
using NewsletterOrganizer.Domain.Newsletters;
using NewsletterOrganizer.Domain.Settings;
using NewsletterOrganizer.Domain.Users;

namespace NewsletterOrganizer.EntityFramework;

public class DatabaseContext : DbContext
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<NewsletterWord> NewsletterWords { get; set; }
    public DbSet<EmailAccount> EmailAccounts { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}