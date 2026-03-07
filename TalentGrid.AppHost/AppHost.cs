var builder = DistributedApplication.CreateBuilder(args);

var userName = builder.AddParameter("username", secret: true, value: "admin");
var password = builder.AddParameter("password", secret: true, value: "admin");

var keycloak = builder.AddKeycloak("keycloak", 8080, userName, password)
                      .WithDataVolume();

var apiService = builder.AddProject<Projects.TalentGrid_Api>("apiservice")
                        .WithReference(keycloak)
                        .WaitFor(keycloak);

builder.Build().Run();
