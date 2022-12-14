using Microsoft.EntityFrameworkCore;
using USSC.Entities;

namespace USSC.Services;

public class DirectionRepository : IDirectionRepository
{
    private readonly DataContext _context;

    public DirectionRepository(DataContext context)
    {
        _context = context;
    }

    public List<DirectionsEntity> GetAll() => _context
        .Set<DirectionsEntity>()
        .Include(d => d.TestCase)
        .Include(d => d.Request)
        .ToList();

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

    public Task<Guid> Update(DirectionsEntity entity)
    {
        throw new NotImplementedException();
    }
}