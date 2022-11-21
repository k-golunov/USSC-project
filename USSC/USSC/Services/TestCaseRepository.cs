using USSC.Entities;
namespace USSC.Services;

public class TestCaseRepository<T>: IEfRepository<T> where T: BaseEntity
{
    private readonly TestCaseDb _context;

    public TestCaseRepository(TestCaseDb context)
    {
        _context = context;
    }
    
    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(long id)
    {
        var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

        if (result == null)
        {
            return null;
        }

        return result;
    }

    public async Task<long> Add(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }
}