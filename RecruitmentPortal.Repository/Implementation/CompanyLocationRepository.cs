using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class CompanyLocationRepository : GenericRepository<CompanyLocation>, ICompanyLocationRepository
{
    private readonly RecruitmentPortalContext _context;

    public CompanyLocationRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }
}
