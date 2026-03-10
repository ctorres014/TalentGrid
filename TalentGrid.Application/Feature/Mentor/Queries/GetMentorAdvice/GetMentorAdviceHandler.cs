using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Services.AI;
using TalentGrid.Domain.Aggregate;
using TalentGrid.Domain.Repositories;

namespace TalentGrid.Application.Feature.Mentor.Queries.GetMentorAdvice
{
    public class GetMentorAdviceHandler: IQueryHandler<GetMentorAdviceQuery, CareerPathDto>
    {
        private readonly IAiService _aiService;
        private readonly IEmployeeRepository _employeeRepository;
        public GetMentorAdviceHandler(IAiService aiService, IEmployeeRepository employeeRepository)
        {
            _aiService = aiService;
            _employeeRepository = employeeRepository;
        }
        public async Task<CareerPathDto> Handle(GetMentorAdviceQuery request)
        {
            var employee = await _employeeRepository.GetEmployeeInformation(request.EmployeeId);
            var skillsNames = employee.EmployeeSkills.Select(es => es.Skill.Name).ToList();
            if (employee == null)
                throw new ArgumentException("Employee not found");

            return await _aiService.GetCareerAdviceAsync(employee.Role, skillsNames, request.TargetRole);
        }
    
    }
}
