using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public class ProfileService : IProfileService
{
    private readonly IEfRepository<ProfileEntity> _profileRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public ProfileService(IEfRepository<ProfileEntity> profileRepository, IConfiguration configuration, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _configuration = configuration;
        _mapper = mapper;
    }
    
    public Task<Guid> Add(ProfileModel profileModel)
    {
        var profile = _mapper.Map<ProfileEntity>(profileModel);
        return _profileRepository.Add(profile);
    }
}