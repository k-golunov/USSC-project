using USSC.Dto;

namespace USSC.Services;

public interface IProfileService
{
    Task<Guid> Add(ProfileModel userModel);
}