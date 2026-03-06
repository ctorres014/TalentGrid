using Microsoft.Extensions.DependencyInjection;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Feature.Skills.Queries.GetSkillsByEmployee;

namespace TalentGrid.Application
{
    public static class ConfigurationServiceApplication
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            // Registrar casos de uso
            services.AddScoped<IQueryHandler<GetSkillsByEmployeeQuery, List<SearchTalentDto>>, GetSkillsByEmployeeHandler>();
      
            return services;
        }   
    }
}
