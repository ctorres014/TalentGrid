using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TelentGrid.Persistence.Context;

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
            //services.AddScoped<IEmployeeSkillsRepository, EmployeeSkillsRepository>();
            return services;
        }
    }
}
