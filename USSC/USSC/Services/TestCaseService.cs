using USSC.Entities;
using AutoMapper;
using USSC.Dto;

namespace USSC.Services;

public class TestCaseService : ITestCaseService
{
    private readonly IEfRepository<TestCase> _testcaseRepository;
    private readonly IMapper _mapper;

    public TestCaseService(IEfRepository<TestCase> testcaseRepository, IMapper mapper)
    {
        _testcaseRepository = testcaseRepository;
        _mapper = mapper;
    }

    public IEnumerable<TestCase> GetAll() => _testcaseRepository.GetAll();

    public TestCase GetById(int id) => _testcaseRepository.GetById(id);
    
    

    public async Task<SuccessResponse> ReviewTestCaseAsync(User user, ReviewTestCaseModel caseModel)
    {
        var model = _mapper.Map<TestCase>(caseModel);
        user.TestCaseId = model.Id;
    
        await _testcaseRepository.Add(model);

        return  new SuccessResponse(true);
    }

    public string DownLoad(int testCaseId)
    {
        return _testcaseRepository.GetById(testCaseId).Path;
    }
}