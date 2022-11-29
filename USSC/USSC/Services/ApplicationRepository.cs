using USSC.Entities;
namespace USSC.Services;

public class ApplicationRepository : IApplicationRepository
{
    private readonly DataContext _context;

    public ApplicationRepository(DataContext context)
    {
        _context = context;
    }

    public List<UsersDirectionsfkEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public UsersDirectionsfkEntity GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Add(UsersDirectionsfkEntity entity)
    {
        var result = await _context.Set<UsersDirectionsfkEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public Task<Guid> Update(T entity)
    {
        throw new NotImplementedException();
    }
}