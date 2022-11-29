using USSC.Entities;

namespace USSC.Services;

//create baseEntity and DataContext

public class UserRepository<T> : IEfRepository<T> where T : BaseEntity
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(Guid id)
    {
        var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

        //todo: need to add logger
        return result ?? null;
    }

    public async Task<Guid> Add(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }
}