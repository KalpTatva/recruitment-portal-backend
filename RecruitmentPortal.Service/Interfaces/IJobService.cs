using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using static RecruitmentPortal.Repository.Helpers.Enums;

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
        int maxSalary = 0,
        int sorting = (int)SortingEnum.SortByLatest,
        int pageNumber = 1,
        int pageSize = 6
    );
    Task<ResponseViewModel<City>> GetCitiesList();
    Task<ResponseViewModel<CategoryFilterViewModel>> GetCategoryFilters();
    Task<ResponseViewModel<JobType>> GetJobTypeFilters();
    Task<ResponseViewModel<JobDetailsViewModel>> GetJobDetails(int jodId);
}
