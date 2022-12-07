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

    public async Task<SuccessResponse> ProcessRequest(RequestModel model)
    {
        var request = _applicationRepository.GetByUserId(model.UserId, model.DirectionId);
        if (request.Allow == null)
        {
            request.Allow = model.Allow;
            var id = await _applicationRepository.Update(request);
            return  new SuccessResponse(request.Id == id);
        }
        return new SuccessResponse(false);
    }

    public IEnumerable<RequestEntity> GetAll() => _applicationRepository.GetAll();

    public RequestEntity GetById(Guid id) => _applicationRepository.GetById(id);
}