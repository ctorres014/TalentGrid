using System;
using System.Collections.Generic;
using System.Text;

namespace TalentGrid.Domain.Aggregate
{
    public class Endorsement
    {
        public int Id { get; set; }
        public int GiverEmployeeId { get; set; } // Quién valida
        public int EmployeeSkill_EmployeeId { get; set; } // A quién validan
        public int EmployeeSkill_SkillId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Comment { get; set; }
    }
}
