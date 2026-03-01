using TalentGrid.Application.Contracts;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Contracts.UseCase;

namespace TalentGrid.Application.UseCase
{
    public class SearchTalent: ISearchTalent
    {
        private readonly IEmployeeSkillsRepository _employeeSkillsRepository;

        public SearchTalent(IEmployeeSkillsRepository employeeSkillsRepository)
        {
            _employeeSkillsRepository = employeeSkillsRepository;
        }

        public async Task<List<SearchTalentDto>> SearchTalents(string skillName, int minLevel)
            => await _employeeSkillsRepository.GetEmployeeSkills(skillName, minLevel);
    }
}
