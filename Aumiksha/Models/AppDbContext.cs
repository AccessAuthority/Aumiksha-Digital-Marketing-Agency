using Microsoft.EntityFrameworkCore;

namespace Aumiksha.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<form_T> form_T { get; set; }
        public DbSet<AdminTable> AdminTable { get; set; }
    }
}
