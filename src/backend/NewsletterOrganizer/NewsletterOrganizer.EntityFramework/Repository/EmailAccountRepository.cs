using Microsoft.EntityFrameworkCore;
using NewsletterOrganizer.Domain.Users;

namespace NewsletterOrganizer.EntityFramework.Repository;

public class EmailAccountRepository : IRepository<EmailAccount>
{
    private readonly DatabaseContext _context;

    public EmailAccountRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<EmailAccount>> GetAll()
    {
        return await _context.EmailAccounts.ToListAsync();
    }

    public async Task<EmailAccount?> Get(int id)
    {
        return await _context.EmailAccounts.SingleOrDefaultAsync(r => r.Id == id);
    }

    public async Task<EmailAccount> Create(EmailAccount model)
    {
        var entity = await _context.EmailAccounts.AddAsync(model);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<EmailAccount> Update(EmailAccount model)
    {
        var entity = _context.EmailAccounts.Update(model);
        await _context.SaveChangesAsync();

        return entity.Entity;    }

    public async Task<EmailAccount> Delete(int id)
    {
        var entity = _context.EmailAccounts.Single(r => r.Id == id);

        _context.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}