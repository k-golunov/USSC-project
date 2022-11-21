using USSC.Entities;
namespace USSC.Services;

public class ApplicationRepository<T>: IEfRepository<T> where T: BaseEntity
{
    private readonly DataContext _context;

    public ApplicationRepository(DataContext context)
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

        if (result == null)
        {
            return null;
        }

        return result;
    }

    public async Task<Guid> Add(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }
}