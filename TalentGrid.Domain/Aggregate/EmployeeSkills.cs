namespace TalentGrid.Domain.Aggregate
{
    public sealed class EmployeeSkills
    {
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public int SkillId { get; private set; }
        public Skill Skill { get; private set; } = null!;

        public int ProficiencyLevel { get; private set; } // 1 (Básico) al 5 (Experto)

        public List<Endorsement> Endorsements { get; set; } = new(); // Aprobacion

        public EmployeeSkills() { }

        private EmployeeSkills(int employeeId, int skillId, int proficiencyLevel)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
            ProficiencyLevel = proficiencyLevel;
        }

        public static EmployeeSkills Create(int employeeId, int skillId, int proficiencyLevel)
        {
            if (proficiencyLevel < 1 || proficiencyLevel > 5)
                throw new ArgumentOutOfRangeException(nameof(proficiencyLevel), "Proficiency level must be between 1 and 5.");
            return new EmployeeSkills(employeeId, skillId, proficiencyLevel);
        }
    }
}
