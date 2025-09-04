using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Interfaces;

public interface IJobRepository : IGenericRepository<Job>
{
    Task<List<ListOfJobsViewModel>> GetJobDetails();
    Task<List<ListOfJobsViewModel>> GetJobDetailsByFilters(
        int categoryId = 0,
        string searchInput = "",
        int location = 0,
        int jobType = 0,
        int experience = 0,
        int datePost = 0,
        int minSalary = 0,
        int maxSalary = 0
    );
}
