using USSC.Entities;

namespace USSC.Services;

public class DirectionRepository : IDirectionRepository
{
    private readonly DataContext _context;

    public DirectionRepository(DataContext context)
    {
        _context = context;
    }
    public List<DirectionsEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public DirectionsEntity GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Add(DirectionsEntity entity)
    {
        var result = await _context.Set<DirectionsEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }
}