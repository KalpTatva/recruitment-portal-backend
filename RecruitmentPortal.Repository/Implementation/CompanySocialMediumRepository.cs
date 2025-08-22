using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class CompanySocialMediumRepository : GenericRepository<CompanySocialMedium>, ICompanySocialMediumRepository
{
    private readonly RecruitmentPortalContext _context;
    public CompanySocialMediumRepository(RecruitmentPortalContext context) : base (context)
    {
        _context = context;
    }
}
