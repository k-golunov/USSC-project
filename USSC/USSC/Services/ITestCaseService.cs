using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface ITestCaseService: IService<TestCaseEntity>
{
    public Task<SuccessResponse> ReviewTestCaseAsync(UsersEntity user, TestCaseEntity testCase, ReviewedTestCase review);

    public Task<Guid> Upload(UsersEntity user, Guid directionId, string path);
    public string DownLoad(Guid userId, Guid directionId);

}