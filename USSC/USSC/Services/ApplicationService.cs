using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public class ApplicationService: IApplicationService, IDisposable
{
    private readonly IEfRepository<Application> _applicationRepository;
    private readonly IMapper _mapper;
    
    public ApplicationService(IEfRepository<Application> applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<Application> GetAll() => _applicationRepository.GetAll();

    public Application GetById(int id) => _applicationRepository.GetById(id);

    public async Task<IActionResult> SubmitApplicationAsync(ApplicationModel applicationModel)
    {
        var application = _mapper.Map<Application>(applicationModel);

        await _applicationRepository.Add(application);

        return new OkResult();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}