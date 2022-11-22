using Microsoft.EntityFrameworkCore;
using USSC.Entities;
using System.Threading.Tasks;
using USSC.Dto;

namespace USSC;

public class DataContext : DbContext
{
    public DbSet<UsersEntity> Users { get; set; }
    public DbSet<ApplicationDirectionsfkEntity> ApplicationDirectionsfk { get; set; }
    public DbSet<ApplicationEntity> Application { get; set; }
    public DbSet<DirectionsEntity> Directions { get; set; }
    public DbSet<PracticesEntity> Practices { get; set; }
    public DbSet<TeachersEntity> Teachers { get; set; }
    public DbSet<UsersPracticesfkEntity> UsersPracticesfk { get; set; }
    public DbSet<TestCaseEntity> TestCase { get; set; }

    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }
        
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}