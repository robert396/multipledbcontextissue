using Microsoft.EntityFrameworkCore;
using MultipleDbIssues.Data.Models;

namespace MultipleDbIssues.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> opts) : base(opts) { }

        public DbSet<Client> Clients { get; set; }
    }
}