using Microsoft.EntityFrameworkCore;
using TalentGrid.Domain.Aggregate;
using TalentGrid.Domain.Repositories;
using TelentGrid.Persistence.Context;

namespace TelentGrid.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly TalentGridDbContext _context;

        public EmployeeRepository(TalentGridDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetByEmailAsync(string email)
            => await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
    }
}
