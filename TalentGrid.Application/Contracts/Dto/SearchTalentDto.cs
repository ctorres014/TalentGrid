using System;
using System.Collections.Generic;
using System.Text;

namespace TalentGrid.Application.Contracts.Dto
{
    public class SearchTalentDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string SkillName { get; set; } = string.Empty;
        public int Level { get; set; }
        public int EndorsementsCount { get; set; }
    }
}
