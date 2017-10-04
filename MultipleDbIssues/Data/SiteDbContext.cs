using Microsoft.EntityFrameworkCore;
using MultipleDbIssues.Data.Models;

namespace MultipleDbIssues.Data
{
    public class SiteDbContext : DbContext
    {
        public SiteDbContext(DbContextOptions<SiteDbContext> opts) : base(opts) { }

        public DbSet<Site> Sites { get; set; }
    }
}