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

                    Analiza al empleado:
                    - Rol Actual: '{currentRole}'
                    - Habilidades: [{skillsList}]
                    - Objetivo: '{targetRole}'

                    Tu tarea es:
                    1. Identificar habilidades faltantes (técnicas o blandas)
                    2. Generar recomendaciones que AYUDEN DIRECTAMENTE a cubrir esas habilidades

                    REGLAS IMPORTANTES:
                    - Las recomendaciones DEBEN estar alineadas con las habilidades faltantes
                    - Si faltan habilidades blandas (ej: liderazgo, comunicación), NO recomiendes proyectos técnicos
                    - En ese caso, recomienda recursos de aprendizaje como:
                        - libros (recomandar de oreally)
                        - cursos
                        - videos de YouTube
                    - Si faltan habilidades técnicas, puedes recomendar proyectos prácticos y tambien sugerir recursos de aprendizaje:
                        - libros (recomandar de oreally)
                        - cursos
                        - videos de YouTube
                    En cada una de las recomendaciones, si es posible, deja el link del recurso recomendado.
                    Responde ÚNICAMENTE en JSON con esta estructura:

                    {{
                        ""summary"": ""Breve análisis"",
                        ""missingSkills"": [
                        {{ ""skillName"": ""Nombre"", ""importance"": ""Alta/Media"", ""why"": ""Razón"" }}
                        ],
                        ""recommendations"": [
                        {{
                            ""type"": ""book|course|youtube|project"",
                            ""title"": ""Nombre del recurso"",
                            ""description"": ""Por qué ayuda a cubrir la habilidad faltante""
                        }}
                        ],
                        ""motivationQuote"": ""Frase corta""
                    }}

                    RESTRICCIONES:
                    - No mezclar tipos incoherentes (ej: liderazgo → proyecto técnico)
                    - Las recomendaciones deben explicar claramente qué habilidad cubren
                    - JSON válido, completo y sin texto adicional
                    ";


            var response = "";
            await foreach (var stream in _ollamaClient.GenerateAsync(prompt))
            {
                response += stream.Response;
            }

            try
            {
                var careerPath = JsonSerializer.Deserialize<CareerPathDto>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return careerPath ?? new CareerPathDto { Summary = "" };
            }
            catch (JsonException)
            {

                return new CareerPathDto { Summary = "Error al procesar el plan de carrera." };
            }

        }
    }
}
