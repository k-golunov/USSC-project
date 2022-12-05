using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface IApplicationRepository : IEfRepository<RequestEntity>
{
    public RequestEntity GetByUserId(Guid userId, Guid directionId);
}