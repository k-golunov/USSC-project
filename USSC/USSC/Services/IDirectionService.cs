using USSC.Dto;

namespace USSC.Services;

public interface IDirectionService 
{
    Task<Guid> Add(DirectionsModel userModel);
}