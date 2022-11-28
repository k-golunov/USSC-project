using USSC.Entities;

namespace USSC.Services;

public interface ITestCaseRepository: IEfRepository<TestCaseEntity>
{
    public TestCaseEntity GetByUserId(Guid userId, Guid directionId);
}