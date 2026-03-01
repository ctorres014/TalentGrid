using Microsoft.EntityFrameworkCore;
using TalentGrid.Application.Contracts;
using TalentGrid.Application.Contracts.Dto;
using TelentGrid.Persistence.Context;

namespace TelentGrid.Persistence.Repositories
{
    public class EmployeeSkillsRepository : IEmployeeSkillsRepository
    {
        private readonly TalentGridDbContext _context;

        public EmployeeSkillsRepository(TalentGridDbContext context)
        {
            _context = context;
        }
        public async Task<List<SearchTalentDto>> GetEmployeeSkills(string skillName, int minLevel = 1)
        {
            return await _context.EmployeesSkills
                        .AsNoTracking()
                        .Where(es => es.Skill.Name.Contains(skillName) && es.ProficiencyLevel >= minLevel)
                        .Select(es => new SearchTalentDto
                        {
                           FullName = es.Employee.FullName,
                           Role = es.Employee.Role,
                           SkillName = es.Skill.Name,
                           Level = es.ProficiencyLevel,
                           EndorsementsCount = es.Endorsements.Count
                        })
                        .OrderByDescending(r => r.EndorsementsCount) // El "Top Talent" primero
                        .ThenByDescending(r => r.Level)
                        .ToListAsync();
        }
    }
}
