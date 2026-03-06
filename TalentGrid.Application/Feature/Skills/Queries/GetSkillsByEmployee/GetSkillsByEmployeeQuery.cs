namespace TalentGrid.Application.Feature.Skills.Queries.GetSkillsByEmployee
{
    public class GetSkillsByEmployeeQuery
    {
        public string SkillName { get; set; } = string.Empty;
        public int MinLevel { get; set; } = 1;
    }
}
