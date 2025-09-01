using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class JobTypeRepository : GenericRepository<JobType> , IJobTypeRepository 
{
    private readonly RecruitmentPortalContext _context;

    public JobTypeRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }
}
