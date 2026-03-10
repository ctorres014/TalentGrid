using TalentGrid.Application.Contracts.Dto;

namespace TalentGrid.Application.Services.AI
{
    public interface IAiService
    {
        Task<CareerPathDto> GetCareerAdviceAsync(string currentRole, List<string> skills, string targetRole);
    }
}
