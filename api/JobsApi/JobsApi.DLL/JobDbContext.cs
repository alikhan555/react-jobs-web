using JobsApi.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.DLL
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
    }
}
