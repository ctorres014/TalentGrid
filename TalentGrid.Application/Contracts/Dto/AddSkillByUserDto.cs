namespace TalentGrid.Application.Contracts.Dto
{
    public class AddSkillByUserDto
    {
        public string UserEmail { get; set; }
        public int SkillId { get; set; }
        public int Level { get; set; }
    }
}
