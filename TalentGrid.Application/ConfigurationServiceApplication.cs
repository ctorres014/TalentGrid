using Microsoft.Extensions.DependencyInjection;
using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Feature.EmployeeSkill.Command.AddEmployeeSkills;
using TalentGrid.Application.Feature.EmployeeSkill.Queries.GetSkillsByEmployee;
using TalentGrid.Application.Feature.Endorsment.Command.AddEndorsmentSkills;
using TalentGrid.Application.Feature.Mentor.Queries.GetMentorAdvice;
using TalentGrid.Application.Services.AI;

namespace TalentGrid.Application
{
    public static class ConfigurationServiceApplication
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispacher>();
            // Register AI Service
            services.AddScoped<IAiService, AiService>();

            // Registrar Handlers
            services.AddScoped<IQueryHandler<GetSkillsByEmployeeQuery, List<SearchTalentDto>>, GetSkillsByEmployeeHandler>();
            services.AddScoped<ICommandHandler<AddEmployeeSkillsCommand>, AddEmployeeSkillsHandler>();
            services.AddScoped<ICommandHandler<AddEndorsmentSkillsCommand>, AddEndorsmentSkillsHandler>();
            services.AddScoped<IQueryHandler<GetMentorAdviceQuery, CareerPathDto>, GetMentorAdviceHandler>();

            return services;
        }   
    }
}
