using TalentGrid.Application;
using TelentGrid.Persistence;

namespace TalentGrid.Api
{
    public static class StartupExtension
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        { 
            builder.Services.AddServiceApplication();
            builder.Services.AddServicePersistence(builder.Configuration.GetConnectionString("TalentGridDbContextConnection"));
            return builder.Build();
        }
    }
}
