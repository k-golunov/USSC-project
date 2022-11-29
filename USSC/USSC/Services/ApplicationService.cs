using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public class ApplicationService: IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public ApplicationService(IApplicationRepository applicationRepository, IConfiguration configuration, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _configuration = configuration;
        _mapper = mapper;
    }
    public Task<Guid> Add(RequestModel model)
    {
        var application = _mapper.Map<RequestEntity>(model);
        return _applicationRepository.Add(application);
    }
}