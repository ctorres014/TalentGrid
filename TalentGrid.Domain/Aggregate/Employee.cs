using System;
using System.Collections.Generic;
using System.Text;

namespace TalentGrid.Domain.Aggregate
{
    public class Employee
    {
        public int Id { get; set; }
        public string ExternalId { get; set; } = string.Empty; // Para vincular con Azure AD / Auth0
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // Ej: Senior Dev, Project Manager

        // Relación con habilidades
        public List<EmployeeSkills> EmployeeSkills { get; set; } = new();
    }
}
