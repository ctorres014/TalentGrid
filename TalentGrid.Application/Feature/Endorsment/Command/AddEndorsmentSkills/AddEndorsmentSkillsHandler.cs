using TalentGrid.Application.Abstraction;
using TalentGrid.Domain.Aggregate;
using TalentGrid.Domain.Contracts;
using TalentGrid.Domain.Repositories;

namespace TalentGrid.Application.Feature.Endorsment.Command.AddEndorsmentSkills
{
    public class AddEndorsmentSkillsHandler : ICommandHandler<AddEndorsmentSkillsCommand>
    {
        private readonly IEndorsmentRepository _endorsmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeSkillsRepository _employeeSkillsRepository;
        public AddEndorsmentSkillsHandler(IEndorsmentRepository endorsmentRepository, 
                                            IEmployeeRepository employeeRepository,
                                            IEmployeeSkillsRepository employeeSkillsRepository)
        {
            _endorsmentRepository = endorsmentRepository;
            _employeeRepository = employeeRepository;
            _employeeSkillsRepository = employeeSkillsRepository;
        }

        public async Task Handle(AddEndorsmentSkillsCommand command)
        {
            var validatorEmployee = await _employeeRepository.GetByEmailAsync(command.Email);
            // Validate if employee if self endorsing
            if (command.TargetEmployeeId == validatorEmployee.Id)
                throw new InvalidOperationException("Employee cannot endorse themselves.");
            // Validate if have the skill register
            var skill = await _employeeSkillsRepository.EmployeeHasSkill(validatorEmployee.Id, command.SkillId);
            if (skill == null)
                throw new InvalidOperationException("The colleague has not yet included this skill in their profile.");
            var endorsment = Endorsement.Create(command.TargetEmployeeId, validatorEmployee.Id, command.ValidatorEmployeeId, command.Comments);
            await _endorsmentRepository.AddAsync(endorsment);
            
        }
    }
}
