using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface ITestCaseService: IService<TestCase>
{
    public Task<SuccessResponse> ReviewTestCaseAsync(BaseEntity entity, ReviewTestCaseModel caseModel);

    public string DownLoad(Guid testCaseId);

}