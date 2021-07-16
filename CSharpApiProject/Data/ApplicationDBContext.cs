using CSharpApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpApiProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Plot> Plot { get; set; }
        public DbSet<Gardener> Gardener { get; set; }
    }
}
