using Microsoft.OpenApi.Models;
using TalentGrid.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TalentGrid API",
        Version = "v1"
    });

    //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    //{
    //    Type = SecuritySchemeType.OAuth2,
    //    Flows = new OpenApiOAuthFlows
    //    {
    //        AuthorizationCode = new OpenApiOAuthFlow
    //        {
    //            AuthorizationUrl = new Uri("https://localhost:8080/realms/TalentGrid/protocol/openid-connect/auth"),
    //            TokenUrl = new Uri("https://localhost:8080/realms/TalentGrid/protocol/openid-connect/token"),
    //            Scopes = new Dictionary<string, string>
    //                {
    //                    { "openid", "OpenID" },
    //                    { "profile", "Profile" }
    //                }
    //        }
    //    }
    //});

    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "oauth2"
    //            }
    //        },
    //        new[] { "openid", "profile" }
    //    }
    //});

});


var app = builder
    .ConfigureService()// Custom extension method to configure application services and persistence
    .ConfigurePipeLine(); // Custom extension method to configure the HTTP request pipeline 

app.InitializeDatabase();
app.Run();
