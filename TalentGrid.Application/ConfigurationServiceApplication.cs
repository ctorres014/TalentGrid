using Microsoft.Extensions.DependencyInjection;
using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Feature.Skills.Command;
using TalentGrid.Application.Feature.Skills.Queries.GetSkillsByEmployee;

namespace TalentGrid.Application
{
    public static class ConfigurationServiceApplication
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispacher>();

            // Registrar Handlers
            services.AddScoped<IQueryHandler<GetSkillsByEmployeeQuery, List<SearchTalentDto>>, GetSkillsByEmployeeHandler>();
            services.AddScoped<ICommandHandler<AddEmployeeSkillsCommand>, AddEmployeeSkillsHandler>();

            return services;
        }   
    }
}
