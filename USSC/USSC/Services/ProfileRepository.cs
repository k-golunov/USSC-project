using USSC.Entities;

namespace USSC.Services;

public class ProfileRepository<T> : IEfRepository<T> where T: BaseEntity
{
    private readonly DataContext _context;

    public ProfileRepository(DataContext context)
    {
        _context = context;
    }
    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Add(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }
}