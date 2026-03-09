using OllamaSharp;

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

        public async Task<string> GetCareerAdviceAsync(string currentRole, List<string> skills, string targetRole)
        {
            var skillsList = string.Join(", ", skills);

            // El "Prompt" es la clave para que la IA sea útil
            var prompt = $@"
            Actúa como un Mentor de Carrera Tech experto. 
            El empleado es actualmente {currentRole} y tiene estas habilidades: {skillsList}.
            Su objetivo es llegar a ser {targetRole}.
            
            Por favor, responde en español de forma concisa:
            1. Identifica las 3 brechas (skills faltantes) más críticas.
            2. Sugiere un proyecto práctico para cerrar esa brecha.
            3. Da un consejo motivador corto.";

            var response = "";
            await foreach (var stream in _ollamaClient.GenerateAsync(prompt))
            {
                response += stream.Response;
            }

            return response;
        }
    }
}
