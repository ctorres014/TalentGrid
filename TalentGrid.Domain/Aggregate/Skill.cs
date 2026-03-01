using System;
using System.Collections.Generic;
using System.Text;

namespace TalentGrid.Domain.Aggregate
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Ej: "C#", "Scrum", "Cloud Architecture"
        public string Category { get; set; } = string.Empty; // Ej: Técnica, Blanda, Idiomas
    }
}
