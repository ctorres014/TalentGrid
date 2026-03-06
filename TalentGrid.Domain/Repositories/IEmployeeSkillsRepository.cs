using TalentGrid.Domain.Aggregate;

namespace TalentGrid.Domain.Contracts
{
    public interface IEmployeeSkillsRepository
    {
        Task<EmployeeSkills> AddEmployeeSkill(EmployeeSkills employeeSkills);
    }
}
