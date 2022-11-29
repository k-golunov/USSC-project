using USSC.Entities;
using AutoMapper;
using USSC.Dto;

namespace USSC.Services;

public class TestCaseService : ITestCaseService
{
    private readonly ITestCaseRepository _testcaseRepository;
    //private readonly IEfRepository<UsersEntity> _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public TestCaseService(ITestCaseRepository testcaseRepository, /*IEfRepository<UsersEntity> userRepository, */IConfiguration configuration, IMapper mapper)
    {
        _testcaseRepository = testcaseRepository;
        //_userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public IEnumerable<TestCaseEntity> GetAll() => _testcaseRepository.GetAll();

    public TestCaseEntity GetById(Guid id) => _testcaseRepository.GetById(id);

    public async Task<SuccessResponse> ReviewTestCaseAsync(UsersEntity user, TestCaseEntity testCase, ReviewedTestCase review)
    {
        var testCaseEntity = _testcaseRepository.GetById(testCase.Id);
        var entity = _mapper.Map<TestCaseEntity>(testCaseEntity);
        await _testcaseRepository.Update(entity);

        return  new SuccessResponse(true);
    }

    public Task<Guid> Upload(UsersEntity user, Guid directionId, string path)
    {
        var model = new TestCaseModel()
        {
            UserId = user.Id,
            Path = path,
            Comment = "",
            Allow = false,
            Users = new UserModel()
            {
                Email = user.Email,
                Password = user.Password,
                RefreshToken = user.RefreshToken,
                Role = user.Role
            },
            DirectionId = directionId
        };
        var entity = _mapper.Map<TestCaseEntity>(model);
        return _testcaseRepository.Add(entity);
    }

    

    public string DownLoad(Guid userId, Guid directionId)
    {
        var testCase = _testcaseRepository.GetByUserId(userId, directionId);
        return testCase != null ? testCase.Path : null;
    }
}