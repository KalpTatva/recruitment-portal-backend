using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class JobRoleRepository : GenericRepository<JobRole>, IJobRoleRepository
{
    private RecruitmentPortalContext _context;
    public JobRoleRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }

}
