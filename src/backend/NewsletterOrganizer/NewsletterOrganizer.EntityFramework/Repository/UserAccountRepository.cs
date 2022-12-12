using Microsoft.EntityFrameworkCore;
using NewsletterOrganizer.Domain.Users;

namespace NewsletterOrganizer.EntityFramework.Repository;

public class UserAccountRepository: IRepository<User>
{
    private readonly DatabaseContext _context;

    public UserAccountRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> Get(int id)
    {
        return await _context.Users.SingleOrDefaultAsync(r => r.Id == id);
    }

    public async Task<User> Create(User model)
    {
        var entity = await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<User> Update(User model)
    {
        var entity = _context.Users.Update(model);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<User> Delete(int id)
    {
        var entity = _context.Users.Single(r => r.Id == id);

        _context.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}