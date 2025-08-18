using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
{
    private readonly RecruitmentPortalContext _context;

    public ProfileRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }

}
