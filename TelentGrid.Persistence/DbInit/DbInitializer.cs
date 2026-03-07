using System;
using System.Collections.Generic;
using System.Text;
using TalentGrid.Domain.Aggregate;
using TelentGrid.Persistence.Context;

namespace TelentGrid.Persistence.DbInit
{
    public class DbInitializer
    {
        public static void Initialize(TalentGridDbContext context)
        {
            // 1. Asegurarnos de que la DB existe
            context.Database.EnsureCreated();

            // 2. Si ya hay empleados, no hacemos nada
            if (context.Employees.Any()) return;

            // 3. Crear Catálogo de Habilidades
            var skills = new List<Skill>
            {
                new() { Name = ".NET Core", Category = "Technical" },
                new() { Name = "React", Category = "Technical" },
                new() { Name = "SQL Server", Category = "Technical" },
                new() { Name = "Docker", Category = "Technical" },
                new() { Name = "Azure", Category = "Technical" },
                new() { Name = "Scrum Master", Category = "Soft Skill" }
            };
            context.Skill.AddRange(skills);
            context.SaveChanges();

            // 4. Crear Empleados
            var employees = new List<Employee>
            {
                new() { FullName = "Ana Tech", Email = "ana@talentgrid.com", Role = "Senior Developer" },
                new() { FullName = "Berto Cloud", Email = "berto@talentgrid.com", Role = "DevOps Engineer" },
                new() { FullName = "Carla Frontend", Email = "carla@talentgrid.com", Role = "Lead React Dev" }
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            // 5. Vincular Habilidades (El "Grid")
            var empSkills = new List<EmployeeSkills>
            {
                // Ana sabe .NET (Nivel 5) y Docker (Nivel 4)
                EmployeeSkills.Create(employees[0].Id, skills[0].Id, 5),
                //new() { EmployeeId = employees[0].Id, SkillId = skills[3].Id, ProficiencyLevel = 4 },
                EmployeeSkills.Create(employees[0].Id, skills[0].Id, 4),
                // Berto es experto en Azure y Docker
                //new() { EmployeeId = employees[1].Id, SkillId = skills[4].Id, ProficiencyLevel = 5 },
                EmployeeSkills.Create(employees[1].Id, skills[4].Id, 5),
                //new() { EmployeeId = employees[1].Id, SkillId = skills[3].Id, ProficiencyLevel = 5 },
                EmployeeSkills.Create(employees[1].Id, skills[3].Id, 5),
                // Carla es experta en React
                //new() { EmployeeId = employees[2].Id, SkillId = skills[1].Id, ProficiencyLevel = 5 }
                EmployeeSkills.Create(employees[2].Id, skills[1].Id, 5),
            };
            context.EmployeesSkills.AddRange(empSkills);
            context.SaveChanges();

            // 6. Agregar algunos Endorsements (Validaciones)
            // Berto valida a Ana en .NET
            var endorsment = Endorsement.Create(employees[1].Id, employees[0].Id, skills[0].Id, "Ana es la mejor arquitecta .NET que conozco.");
            context.Endorsements.Add(endorsment);

            context.SaveChanges();
        }
    }
}

