using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class StateRepository : GenericRepository<State>, IStateRepository
{
    private readonly RecruitmentPortalContext _context;

    public StateRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }
}
