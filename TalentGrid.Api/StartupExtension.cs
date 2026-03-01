using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TalentGrid.Application;
using TelentGrid.Persistence;
using TelentGrid.Persistence.Context;
using TelentGrid.Persistence.DbInit;

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

        public static WebApplication ConfigurePipeLine(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

        public static void InitializeDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TalentGridDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocurrió un error al poblar la DB.");
                }
            }
        }
    }
}
