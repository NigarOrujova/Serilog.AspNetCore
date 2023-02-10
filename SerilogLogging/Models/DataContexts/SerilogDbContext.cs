using Microsoft.EntityFrameworkCore;
using SerilogLogging.Models.Entities;

namespace SerilogLogging.Models.DataContexts
{
    public class SerilogDbContext : DbContext
    {
        public SerilogDbContext(DbContextOptions<SerilogDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
