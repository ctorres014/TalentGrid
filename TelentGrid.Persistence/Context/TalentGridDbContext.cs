using Microsoft.EntityFrameworkCore;
using TalentGrid.Domain.Aggregate;

namespace TelentGrid.Persistence.Context
{
    public class TalentGridDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkills> EmployeesSkills { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Endorsement> Endorsements { get; set; }
        public TalentGridDbContext(DbContextOptions<TalentGridDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TalentGridDbContext).Assembly);
        }   
    }
}
