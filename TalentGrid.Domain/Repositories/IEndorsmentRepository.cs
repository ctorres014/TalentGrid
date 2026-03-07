using TalentGrid.Domain.Aggregate;

namespace TalentGrid.Domain.Repositories
{
    public interface IEndorsmentRepository: IAsyncRepository<Endorsement>
    {
        Task<Endorsement> AddEndorsmentAsync(Endorsement endorsement);
        
    }
}
