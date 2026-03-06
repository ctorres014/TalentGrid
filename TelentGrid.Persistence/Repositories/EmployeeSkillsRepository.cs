using TalentGrid.Domain.Aggregate;
using TalentGrid.Domain.Contracts;
using TelentGrid.Persistence.Context;

namespace TelentGrid.Persistence.Repositories
{
    public class EmployeeSkillsRepository: BaseRepository<EmployeeSkills>, IEmployeeSkillsRepository
    {
        private readonly TalentGridDbContext _context;

        public EmployeeSkillsRepository(TalentGridDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<EmployeeSkills> AddEmployeeSkill(EmployeeSkills employeeSkills)
            => await AddAsync(employeeSkills);
    }
}
