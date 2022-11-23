using USSC.Entities;
using AutoMapper;
using USSC.Dto;

namespace USSC.Services;

public class TestCaseService : ITestCaseService
{
    private readonly IEfRepository<TestCase> _testcaseRepository;
    private readonly IEfRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public TestCaseService(IEfRepository<TestCase> testcaseRepository, IEfRepository<User> userRepository, IMapper mapper)
    {
        _testcaseRepository = testcaseRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<TestCase> GetAll() => _testcaseRepository.GetAll();

    public TestCase GetById(long id) => _testcaseRepository.GetById(id);
    
    

    public async Task<SuccessResponse> ReviewTestCaseAsync(BaseEntity entity, ReviewTestCaseModel caseModel)
    {
        var model = _mapper.Map<TestCase>(caseModel);
        var user = _userRepository.GetById(entity.Id);
         user.TestCaseId = model.Id;
    
        await _testcaseRepository.Add(model);

        return  new SuccessResponse(true);
    }

    public string DownLoad(int testCaseId)
    {
        return _testcaseRepository.GetById(testCaseId).Path;
    }
}