using Microsoft.EntityFrameworkCore;
using USSC.Entities;
using System.Threading.Tasks;

namespace USSC;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }
        
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}