using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Service.Interfaces;

public interface IJobService
{
    Task<ResponseViewModel<string>> AddJobs(AddJobsViewModel addJobs, string email);
    Task<ResponseViewModel<JobListViewModel>> GetJobs();
    Task<ResponseViewModel<JobListViewModel>> GetJobsByFilters(
        int categoryId = 0,
        string searchInput = "",
        int location = 0,
        int jobType = 0,
        int experience = 0,
        int datePost = 0,
        int minSalary = 0,
        int maxSalary = 0
    );
    Task<ResponseViewModel<City>> GetCitiesList();
    Task<ResponseViewModel<CategoryFilterViewModel>> GetCategoryFilters();
    Task<ResponseViewModel<JobType>> GetJobTypeFilters();
}
