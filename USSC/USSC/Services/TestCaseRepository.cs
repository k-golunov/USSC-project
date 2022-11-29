using USSC.Entities;
namespace USSC.Services;


public class TestCaseRepository: ITestCaseRepository
{
    private readonly DataContext _context;

    public TestCaseRepository(DataContext context)
    {
        _context = context;
    }
    
    public List<TestCaseEntity> GetAll()
    {
        return _context.Set<TestCaseEntity>().ToList();
    }

    public TestCaseEntity GetById(Guid id)
    {
        var result = _context.Set<TestCaseEntity>().FirstOrDefault(x => x.Id == id);

        if (result == null)
        {
            return null;
        }

        return result;
    }

    public async Task<Guid> Add(TestCaseEntity entity)
    {
        var result = await _context.Set<TestCaseEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<Guid> Update(TestCaseEntity entity)
    {
        // var result = _context.Set<TestCaseEntity>().FirstOrDefault(x => x.Id == entity.Id);
        // result.Comment = entity.Comment;
        // result.Allow = entity.Allow;
        // await _context.SaveChangesAsync();
        // return result.Id;
        //_context.Set<TestCaseEntity>().Attach(entity);
        //var result = _context.Entry(entity);
        _context.TestCase.Update(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public TestCaseEntity GetByUserId(Guid userId, Guid directionId)
    {
        var testCase = _context.Set<TestCaseEntity>().FirstOrDefault(x =>
            x.UserId == userId && x.DirectionId == directionId);
        return testCase;
    }
}