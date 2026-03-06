using Microsoft.EntityFrameworkCore;
using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Contracts.Dto;
using TelentGrid.Persistence.Context;

namespace TalentGrid.Application.Feature.Skills.Queries.GetSkillsByEmployee
{
    public class GetSkillsByEmployeeHandler : IQueryHandler<GetSkillsByEmployeeQuery, List<SearchTalentDto>>
    {
        private readonly TalentGridDbContext _context;

        public GetSkillsByEmployeeHandler(TalentGridDbContext context)
        {
            _context = context;
        }
        public async Task<List<SearchTalentDto>> Handle(GetSkillsByEmployeeQuery request)
            => await _context.EmployeesSkills
                        .AsNoTracking()
                        .Where(es => es.Skill.Name.Contains(request.SkillName) && es.ProficiencyLevel >= request.MinLevel)
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
