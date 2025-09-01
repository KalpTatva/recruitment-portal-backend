using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class JobCategoryRepository : GenericRepository<JobCategory>, IJobCategoryRepository
{
    private readonly RecruitmentPortalContext _context;
    public JobCategoryRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }

}
