using USSC.Entities;

namespace USSC.Services;

public interface IUserRepository: IEfRepository<UsersEntity>
{
    Task<UsersEntity> GetByUserEmail(string userEmail);
}