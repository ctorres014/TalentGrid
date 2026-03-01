using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TalentGrid.Domain.Aggregate;

namespace TelentGrid.Persistence.Configurations
{
    public class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkills>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkills> builder)
        {
            // Configuración de claves compuestas para EmployeeSkill
            builder.HasKey(es => new { es.EmployeeId, es.SkillId });

            // Configuración de relaciones
            builder.HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId);

            builder.HasOne(es => es.Skill)
                .WithMany()
                .HasForeignKey(es => es.SkillId);
        }
    }
}
