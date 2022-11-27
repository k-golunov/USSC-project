using USSC.Entities;

namespace USSC.Services;

public class ProfileRepository : IProfileRepository
{
    private readonly DataContext _context;

    public ProfileRepository(DataContext context)
    {
        _context = context;
    }
    public List<ProfileEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public ProfileEntity GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Add(ProfileEntity entity)
    {
        var result = await _context.Set<ProfileEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }
}