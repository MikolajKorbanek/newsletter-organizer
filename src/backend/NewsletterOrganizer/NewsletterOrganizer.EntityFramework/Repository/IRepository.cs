namespace NewsletterOrganizer.EntityFramework.Repository;

public interface IRepository<T>
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> Get(int id);
    public Task<T> Create(T model);
    public Task<T> Update(T model);
    public Task<T> Delete(int id);
}