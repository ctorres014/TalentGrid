using TalentGrid.Domain.Aggregate;

namespace TalentGrid.Domain.Repositories
{
    public interface IEmployeeRepository: IAsyncRepository<Employee>
    {
        Task<Employee> GetByEmailAsync(string email);
        Task<Employee> GetEmployeeInformation(int employeeId);
    }
}
