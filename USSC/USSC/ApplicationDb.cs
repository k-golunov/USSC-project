using Microsoft.EntityFrameworkCore;
using USSC.Entities;

namespace USSC;

public class ApplicationDb: DbContext
{
    public DbSet<ApplicationEntity> Applications { get; set; }

    public ApplicationDb(DbContextOptions<ApplicationDb> options): base(options)
    {
    }
        
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}