using RecruitmentPortal.Repository.Implementation;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Interfaces;

public interface IJobCategoryRepository : IGenericRepository<JobCategory>
{
    Task<List<CategoryFilterViewModel>> GetCategoryFilters();
}
