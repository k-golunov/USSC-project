using USSC.Dto;
using USSC.Entities;
namespace USSC.Services;

public class ApplicationRepository : IApplicationRepository
{
    private readonly DataContext _context;

    public ApplicationRepository(DataContext context)
    {
        _context = context;
    }

    public List<RequestEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public RequestEntity GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Add(RequestEntity entity)
    {
        var result = await _context.Set<RequestEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public Task<Guid> Update(RequestEntity entity)
    {
        throw new NotImplementedException();
    }
}