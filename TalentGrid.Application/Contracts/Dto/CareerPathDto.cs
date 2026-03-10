namespace TalentGrid.Application.Contracts.Dto
{
    public class CareerPathDto
    {
        public string Summary { get; set; } = string.Empty;
        public List<SkillGap> MissingSkills { get; set; } = new();
        public SuggestedProject RecommendedProject { get; set; } = new();
        public string MotivationQuote { get; set; } = string.Empty;
    }

    public class SkillGap
    {
        public string SkillName { get; set; } = string.Empty;
        public string Importance { get; set; } = string.Empty; // Alta, Media, Baja
        public string Why { get; set; } = string.Empty;
    }

    public class SuggestedProject
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

}
