using System;
using System.Collections.Generic;
using System.Text;

namespace TalentGrid.Domain.Aggregate
{
    public class EmployeeSkills
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int SkillId { get; set; }
        public Skill Skill { get; set; } = null!;

        public int ProficiencyLevel { get; set; } // 1 (Básico) al 5 (Experto)

        public List<Endorsement> Endorsements { get; set; } = new(); // Aprobacion
    }
}
