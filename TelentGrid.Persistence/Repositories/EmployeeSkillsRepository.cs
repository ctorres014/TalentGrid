using Microsoft.EntityFrameworkCore;
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

        public async Task<EmployeeSkills> EmployeeHasSkill(int employeeId, int skillId)
            => await _context.EmployeesSkills.FirstOrDefaultAsync(es => es.EmployeeId == employeeId
                                                                    && es.SkillId == skillId);
    }
}
