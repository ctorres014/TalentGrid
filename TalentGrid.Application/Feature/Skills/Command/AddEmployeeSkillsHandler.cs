using TalentGrid.Application.Abstraction;
using TalentGrid.Domain.Aggregate;
using TalentGrid.Domain.Contracts;
using TalentGrid.Domain.Repositories;

namespace TalentGrid.Application.Feature.Skills.Command
{
    public class AddEmployeeSkillsHandler : ICommandHandler<AddEmployeeSkillsCommand>
    {
        private readonly IEmployeeSkillsRepository _employeeSkillsRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AddEmployeeSkillsHandler(IEmployeeSkillsRepository employeeSkillsRepository, 
            IEmployeeRepository employeeRepository)
        {
            _employeeSkillsRepository = employeeSkillsRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task Handle(AddEmployeeSkillsCommand command)
        {
            var employee = await _employeeRepository.GetByEmailAsync(command.UserEmail);
            if (employee == null)
                throw new ArgumentException($"Employee with email {command.UserEmail} not found.");

            var employeeSkill = EmployeeSkills.Create(employee.Id, command.SkillId, command.Level);
            await _employeeSkillsRepository.AddEmployeeSkill(employeeSkill);
        }
    }
}
