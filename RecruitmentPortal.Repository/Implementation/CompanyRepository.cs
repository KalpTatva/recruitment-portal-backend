using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    private readonly RecruitmentPortalContext _context;
    public CompanyRepository(RecruitmentPortalContext context) : base (context)
    {
        _context = context;
    }
}
