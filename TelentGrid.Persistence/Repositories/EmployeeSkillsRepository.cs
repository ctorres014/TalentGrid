using TelentGrid.Persistence.Context;

namespace TelentGrid.Persistence.Repositories
{
    public class EmployeeSkillsRepository
    {
        private readonly TalentGridDbContext _context;

        public EmployeeSkillsRepository(TalentGridDbContext context)
        {
            _context = context;
        }
      
    }
}
