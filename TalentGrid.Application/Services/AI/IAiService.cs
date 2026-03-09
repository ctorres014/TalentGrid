namespace TalentGrid.Application.Services.AI
{
    public interface IAiService
    {
        Task<string> GetCareerAdviceAsync(string currentRole, List<string> skills, string targetRole);
    }
}
