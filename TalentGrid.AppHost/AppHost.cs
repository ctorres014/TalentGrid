var builder = DistributedApplication.CreateBuilder(args);

var userName = builder.AddParameter("username", secret: true, value: "admin");
var password = builder.AddParameter("password", secret: true, value: "admin");

var keycloak = builder.AddKeycloak("keycloak", 8080, userName, password)
                      .WithDataVolume();

var ollama = builder.AddOllama("ollama")
                    .WithDataVolume() // Para no re-descargar el modelo cada vez
                    .AddModel("llama3");
                    

var apiService = builder.AddProject<Projects.TalentGrid_Api>("apiservice")
                        .WithReference(keycloak)
                        .WithReference(ollama)
                        .WaitFor(keycloak);

builder.Build().Run();
