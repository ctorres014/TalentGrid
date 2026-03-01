using TalentGrid.Application.Contracts.Dto;

namespace TalentGrid.Application.Contracts.UseCase
{
    public interface ISearchTalent
    {
        Task<List<SearchTalentDto>> SearchTalents(string skillName, int minLevel= 1);
    }
}
