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
        var result = _context.Set<DirectionsEntity>().FirstOrDefault(x => x.Id == id);

        if (result == null)
        {
            //todo: need to add logger
            return null;
        }

        return result;
    }

    public async Task<Guid> Add(DirectionsEntity entity)
    {
        var result = await _context.Set<DirectionsEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public Task<Guid> Update(DirectionsEntity entity)
    {
        throw new NotImplementedException();
    }
}