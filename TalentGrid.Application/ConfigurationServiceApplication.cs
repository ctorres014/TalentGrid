using Microsoft.Extensions.DependencyInjection;
using TalentGrid.Application.Contracts.UseCase;
using TalentGrid.Application.UseCase;

namespace TalentGrid.Application
{
    public static class ConfigurationServiceApplication
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            // Registrar casos de uso
            services.AddScoped<ISearchTalent, SearchTalent>();
      
            return services;
        }   
    }
}
