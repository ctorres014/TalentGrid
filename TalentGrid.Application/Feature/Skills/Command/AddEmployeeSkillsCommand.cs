using System.Windows.Input;

namespace TalentGrid.Application.Feature.Skills.Command
{
    public class AddEmployeeSkillsCommand
    {
        public string UserEmail { get; set; } = string.Empty;
        public int SkillId { get; set; }
        public int Level { get; set; }
    }
}
