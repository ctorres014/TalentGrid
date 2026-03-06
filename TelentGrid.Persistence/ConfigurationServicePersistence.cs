using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TalentGrid.Domain.Contracts;
using TalentGrid.Domain.Repositories;
using TelentGrid.Persistence.Context;
using TelentGrid.Persistence.Repositories;

namespace TelentGrid.Persistence
{
    public static class ConfigurationServicePersistence
    {
        public static IServiceCollection AddServicePersistence(this IServiceCollection services, string connectionString)
        {
            // Registrar el DbContext con la cadena de conexión
            services.AddDbContext<TalentGridDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Registrar repositorios
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeSkillsRepository, EmployeeSkillsRepository>();

            return services;
        }
    }
}
