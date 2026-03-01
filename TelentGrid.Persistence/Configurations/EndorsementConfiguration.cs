using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentGrid.Domain.Aggregate;

namespace TelentGrid.Persistence.Configurations
{
    internal class EndorsementConfiguration : IEntityTypeConfiguration<Endorsement>
    {
        public void Configure(EntityTypeBuilder<Endorsement> builder)
        {
            builder.HasOne<EmployeeSkills>()
               .WithMany(es => es.Endorsements)
               .HasForeignKey(e => new { e.EmployeeSkill_EmployeeId, e.EmployeeSkill_SkillId })
               .OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
