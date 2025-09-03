using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Implementation;

public class JobCategoryRepository : GenericRepository<JobCategory>, IJobCategoryRepository
{
    private readonly RecruitmentPortalContext _context;
    public JobCategoryRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<CategoryFilterViewModel>> GetCategoryFilters()
    {
        try
        {
            List<CategoryFilterViewModel> category = await _context.JobCategories.Select(x => new CategoryFilterViewModel
            {
                JobCategoryId = x.JobCategoryId,
                CategoryName = x.CategoryName
            }).ToListAsync();

            return category;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
