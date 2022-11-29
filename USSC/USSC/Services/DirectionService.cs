using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public class DirectionService : IDirectionService
{
    private readonly IDirectionRepository _directionRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public DirectionService(IDirectionRepository directionRepository, IConfiguration configuration, IMapper mapper)
    {
        _directionRepository = directionRepository;
        _configuration = configuration;
        _mapper = mapper;
    }
    
    public Task<Guid> Add(DirectionsModel directionsModel)
    {
        var profile = _mapper.Map<DirectionsEntity>(directionsModel);
        return _directionRepository.Add(profile);
    }
}