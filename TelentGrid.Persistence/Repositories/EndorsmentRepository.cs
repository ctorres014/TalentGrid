using TalentGrid.Domain.Aggregate;
using TalentGrid.Domain.Repositories;
using TelentGrid.Persistence.Context;

namespace TelentGrid.Persistence.Repositories
{
    public class EndorsmentRepository: BaseRepository<Endorsement>, IEndorsmentRepository
    {
        private readonly TalentGridDbContext _context;

        public EndorsmentRepository(TalentGridDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Endorsement> AddEndorsmentAsync(Endorsement endorsement)
            => await AddAsync(endorsement);


    }
}
