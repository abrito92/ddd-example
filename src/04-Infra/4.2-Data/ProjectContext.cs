using ddd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ddd.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<DomainEntity> DomainEntity { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}