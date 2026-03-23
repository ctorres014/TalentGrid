using CommunityToolkit.Aspire.Hosting.Dapr;
using System.Collections.Immutable;

var builder = DistributedApplication.CreateBuilder(args);

var userName = builder.AddParameter("username", secret: true, value: "admin");
var password = builder.AddParameter("password", secret: true, value: "admin");

var keycloak = builder.AddKeycloak("keycloak", 8080, userName, password)
                      .WithDataVolume();

// we start MongoDB
var mongodb = builder.AddMongoDB("mongodb", port: 27017)
                     .WithLifetime(ContainerLifetime.Persistent)
                     .WithDataVolume();
// we define db
//var stateDb = mongodb.AddDatabase("statedb");

// we define statestore of Dapr
var stateStore = builder.AddDaprStateStore("statestore-mongo", new DaprComponentOptions
{
    LocalPath = "components"
});
                 

// we start ollama with the llama3 model
var ollama = builder.AddOllama("ollama", port: 11434)
                    .WithDataVolume() // Para no re-descargar el modelo cada vez
                    .AddModel("llama3");


var apiService = builder.AddProject<Projects.TalentGrid_Api>("apiservice")
                        .WithDaprSidecar(new DaprSidecarOptions
                        {
                            ResourcesPaths = ImmutableHashSet.Create("components") // solo lee de acá
                        })
                        .WithReference(mongodb)
                        .WithReference(keycloak)
                        .WithReference(ollama)
                        .WaitFor(keycloak)
                        .WaitFor(mongodb);

builder.Build().Run();
