using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
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

            //AddAuthentication(builder);
            builder.Services.AddAuthentication()
                .AddKeycloakJwtBearer(
                    serviceName: "keycloak",
                    realm: "TalentGrid",
                    configureOptions: options =>
                    {
                        options.Audience = builder.Configuration["Keycloak:Audience"]; // Client ID configurado en Keycloak
                        //options.Authority = builder.Configuration["Keycloak:Authority"];
                        if(builder.Environment.IsDevelopment())
                        {
                            options.RequireHttpsMetadata = false; // Solo para desarrollo
                        }
                    }
                );
            builder.Services.AddAuthorizationBuilder();

            builder.AddOllamaApiClient("llama");
           
            return builder.Build();
        }

        public static WebApplication ConfigurePipeLine(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.OAuthClientId("TalentGrid");
                    options.OAuthUsePkce();
                });
            }
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
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

        private static void AddAuthentication(this WebApplicationBuilder builder) 
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };

            });
        
        }
    }
}
