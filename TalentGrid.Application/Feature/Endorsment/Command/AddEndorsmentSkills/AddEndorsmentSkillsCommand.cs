namespace TalentGrid.Application.Feature.Endorsment.Command.AddEndorsmentSkills
{
    public class AddEndorsmentSkillsCommand
    {
        public string Email { get; set; } = string.Empty;
        public int TargetEmployeeId { get; set; }
        public int ValidatorEmployeeId { get; set; }
        public int SkillId { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime CreateAt = DateTime.UtcNow;
    }
}
