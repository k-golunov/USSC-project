using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface ITestCaseService: IService<TestCaseEntity>
{
    public Task<SuccessResponse> ReviewTestCaseAsync(TestCaseModel testCaseModel);

    public Task<Guid> Upload(TestCaseModel testCaseModel);
    public string DownLoad(Guid userId, Guid directionId);

}