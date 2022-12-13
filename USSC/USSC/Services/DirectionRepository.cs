using Serilog.Context;
using USSC.Entities;

namespace USSC.Services;

public class DirectionRepository : IDirectionRepository
{
    private readonly DataContext _context;
    public readonly ILogger<DirectionsEntity> _logger;

    public DirectionRepository(DataContext context, ILogger<DirectionsEntity> logger)
    {
        _context = context;
        _logger = logger;
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
            LogContext.PushProperty("Source", "DirectionRepository");
            _logger.LogInformation("No data with this infomation");
            
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