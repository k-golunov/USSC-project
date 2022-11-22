using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public class ApplicationService: IApplicationService, IDisposable
{
    private readonly IEfRepository<Application> _applicationRepository;
    private readonly IEfRepository<User> _userRepository;
    private readonly IMapper _mapper;
    
    public ApplicationService(IEfRepository<Application> applicationRepository, IEfRepository<User> userRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<Application> GetAll() => _applicationRepository.GetAll();

    public Application GetById(long id) => _applicationRepository.GetById(id);

    public async Task<SuccessResponse> SubmitApplicationAsync(BaseEntity entity, ApplicationModel applicationModel)
    {
        var application = _mapper.Map<Application>(applicationModel);
        var user = _userRepository.GetById(entity.Id);
        user.ApplicationId = application.Id;

        await _applicationRepository.Add(application);

        return new SuccessResponse(true);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}