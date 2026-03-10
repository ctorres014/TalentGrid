using OllamaSharp;
using System.Text.Json;
using TalentGrid.Application.Contracts.Dto;

namespace TalentGrid.Application.Services.AI
{
    public class AiService : IAiService
    {
        private readonly IOllamaApiClient _ollamaClient;

        public AiService(IOllamaApiClient ollamaClient)
        {
            _ollamaClient = ollamaClient;
            _ollamaClient.SelectedModel = "llama3.2:latest";
        }

        public async Task<CareerPathDto> GetCareerAdviceAsync(string currentRole, List<string> skills, string targetRole)
        {
            var skillsList = string.Join(", ", skills);

            // Prompt de Ingeniería de Datos
            var prompt = $@"
                Eres un sistema de Inteligencia Organizacional. 
                Analiza al empleado: Rol Actual '{currentRole}', Habilidades: [{skillsList}]. 
                Objetivo: '{targetRole}'.

                Responde ÚNICAMENTE en formato JSON siguiendo esta estructura exacta:
                {{
                  ""summary"": ""Breve análisis de la situación"",
                  ""missingSkills"": [
                    {{ ""skillName"": ""Nombre"", ""importance"": ""Alta/Media"", ""why"": ""Razón"" }}
                  ],
                  ""recommendedProject"": {{ ""title"": ""Nombre del proyecto"", ""description"": ""Detalle"" }},
                  ""motivationQuote"": ""Frase corta""
                }}
                No incluyas texto adicional antes ni después del JSON.";

            var response = "";
            await foreach (var stream in _ollamaClient.GenerateAsync(prompt))
            {
                response += stream.Response;
            }

            try
            {
                return JsonSerializer.Deserialize<CareerPathDto>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (JsonException)
            {

                return new CareerPathDto { Summary = "Error al procesar el plan de carrera." };
            }

        }
    }
}
