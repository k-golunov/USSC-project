using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public class ApplicationService: IApplicationService, IDisposable
{
    private readonly IEfRepository<ApplicationEntity> _applicationRepository;
    private readonly IMapper _mapper;
    
    public ApplicationService(IEfRepository<ApplicationEntity> applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<ApplicationEntity> GetAll() => _applicationRepository.GetAll();

    public ApplicationEntity GetById(Guid id) => _applicationRepository.GetById(id);

    public async Task<SuccessResponse> SubmitApplicationAsync(BaseEntity entity, ApplicationModel applicationModel)
    {
        var application = _mapper.Map<ApplicationEntity>(applicationModel);

        await _applicationRepository.Add(application);

        return new SuccessResponse(true);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}