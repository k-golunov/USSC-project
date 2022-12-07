using Microsoft.EntityFrameworkCore;
using USSC.Entities;

namespace USSC.Services;

//create baseEntity and DataContext

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public List<UsersEntity> GetAll()
    {
        return _context.Set<UsersEntity>().ToList();
    }

    public UsersEntity GetById(Guid id)
    {
        var result = _context.Set<UsersEntity>().FirstOrDefault(x => x.Id == id);

        if (result == null)
        {
            //todo: need to add logger
            return null;
        }

        return result;
    }

    public async Task<Guid> Add(UsersEntity entity)
    {
        var result = await _context.Set<UsersEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<Guid> Update(UsersEntity entity)
    {
        var result = _context.Set<UsersEntity>().FirstOrDefault(x => x.Id == entity.Id);
        await _context.SaveChangesAsync();
        return result.Id;
    }

    public async Task<Guid> UpdateRefreshToken(UsersEntity entity, string refreshToken)
    {
        var result = _context.Set<UsersEntity>().FirstOrDefault(x => x.Id == entity.Id);
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}