using Dapr.Client;
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
        private readonly DaprClient _daprClient;
        private const string STORE_NAME = "statestore-mongo";
        public GetMentorAdviceHandler(IAiService aiService, IEmployeeRepository employeeRepository,
                                    DaprClient daprClient)
        {
            _aiService = aiService;
            _employeeRepository = employeeRepository;
            _daprClient = daprClient;
        }
        public async Task<CareerPathDto> Handle(GetMentorAdviceQuery request)
        {
            var employee = await _employeeRepository.GetEmployeeInformation(request.EmployeeId);
            var skillsNames = employee.EmployeeSkills.Select(es => es.Skill.Name).ToList();
            if (employee == null)
                throw new ArgumentException("Employee not found");
            var careerAdvice = await _aiService.GetCareerAdviceAsync(employee.Role, skillsNames, request.TargetRole);

            if (!string.IsNullOrEmpty(careerAdvice.Summary))
            {
                string stateKey = $"advice-{request.EmployeeId}";
                await _daprClient.SaveStateAsync(STORE_NAME, stateKey, careerAdvice, new StateOptions()
                {
                    Consistency = ConsistencyMode.Eventual
                });
            }
            //var lastDeviceAsync = GetLastDeviceAsync(request.EmployeeId);  
            return careerAdvice;
        }

        private async Task<CareerPathDto> GetLastDeviceAsync(int employeeId)
        {
            return await _daprClient.GetStateAsync<CareerPathDto>(STORE_NAME, $"advice-{employeeId}");
        }
    
    }
}
