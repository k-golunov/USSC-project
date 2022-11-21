using Microsoft.EntityFrameworkCore;
using USSC.Entities;

namespace USSC;

public class TestCaseDb: DbContext
{
    public DbSet<TestCase> TestCases { get; set; }

    public TestCaseDb(DbContextOptions<TestCaseDb> options): base(options)
    {
    }
        
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}