using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface IProfileService
{
    Task<Guid> Add(ProfileModel userModel);

    ProfileEntity GetById(Guid id);

    Task<Guid> Update(ProfileModel profileModel);
}