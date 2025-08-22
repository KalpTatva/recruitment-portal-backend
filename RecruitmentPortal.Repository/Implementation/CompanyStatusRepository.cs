using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class CompanyStatusRepository : GenericRepository<CompanyStatus>, ICompanyStatusRepository
{
    private readonly RecruitmentPortalContext _context;
    public CompanyStatusRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }
}
