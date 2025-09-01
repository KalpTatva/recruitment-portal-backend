using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class DegreeRepository : GenericRepository<Degree>, IDegreeRepository
{
    private RecruitmentPortalContext _context;
    public DegreeRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }

}
