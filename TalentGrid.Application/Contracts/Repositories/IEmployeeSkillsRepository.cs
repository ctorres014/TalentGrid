using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Domain.Aggregate;

namespace TalentGrid.Application.Contracts
{
    public interface IEmployeeSkillsRepository
    {
        Task<List<SearchTalentDto>> GetEmployeeSkills(string skillName, int minLevel=1);
    }
}
