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

    public async Task<SuccessResponse> ReviewTestCaseAsync(TestCaseModel testCaseModel)
    {
        var testCaseEntity = _testcaseRepository.GetById(testCaseModel.Id);
        testCaseEntity.Comment = testCaseModel.Comment;
        testCaseEntity.Allow = testCaseModel.Allow;
        await _testcaseRepository.Update(testCaseEntity);

        return  new SuccessResponse(true);
    }

    public Task<Guid> Upload(TestCaseModel testCaseModelmodel)
    {
        // var model = new TestCaseModel()
        // {
        //     UserId = testCaseModelmodel.UserId,
        //     Path = testCaseModelmodel.Path,
        //     Comment = testCaseModelmodel.Comment,
        //     Allow = false,
        //     Users = new UserModel()
        //     {
        //         Email = user.Email,
        //         Password = user.Password,
        //         RefreshToken = user.RefreshToken,
        //         Role = user.Role
        //     },
        //     DirectionId = directionId
        // };
        var entity = _mapper.Map<TestCaseEntity>(testCaseModelmodel);
        return _testcaseRepository.Add(entity);
    }

    

    public string DownLoad(Guid userId, Guid directionId)
    {
        var testCase = _testcaseRepository.GetByUserId(userId, directionId);
        return testCase != null ? testCase.Path : null;
    }
}