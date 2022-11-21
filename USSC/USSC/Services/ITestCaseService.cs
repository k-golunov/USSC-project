using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface ITestCaseService: IService<TestCase>
{
    public Task<SuccessResponse> ReviewTestCaseAsync(User user, ReviewTestCaseModel caseModel);

    public string DownLoad(int testCaseId);

}