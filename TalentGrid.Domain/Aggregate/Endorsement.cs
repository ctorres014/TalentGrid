namespace TalentGrid.Domain.Aggregate
{
    public sealed class Endorsement
    {
        public int Id { get; private set; }
        public int GiverEmployeeId { get; private set; } // Quién valida
        public int EmployeeSkill_EmployeeId { get; private set; } // A quién validan
        public int EmployeeSkill_SkillId { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public string? Comment { get; private set; }

        public Endorsement() { }

        private Endorsement(int giverEmployeeId, int employeeSkill_EmployeeId, int employeeSkill_SkillId, string? comment)
        {
            GiverEmployeeId = giverEmployeeId;
            EmployeeSkill_EmployeeId = employeeSkill_EmployeeId;
            EmployeeSkill_SkillId = employeeSkill_SkillId;
            Comment = comment;
        }

        public static Endorsement Create(int giverEmployeeId, int employeeSkill_EmployeeId, int employeeSkill_SkillId, string? comment)
        {
            // Aquí puedes agregar validaciones si es necesario
            return new Endorsement(giverEmployeeId, employeeSkill_EmployeeId, employeeSkill_SkillId, comment);
        }
    }
}
