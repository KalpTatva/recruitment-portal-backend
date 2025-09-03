using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Interfaces;

public interface IJobRepository : IGenericRepository<Job>
{
    Task<List<ListOfJobsViewModel>> GetJobDetails();
    Task<List<ListOfJobsViewModel>> GetJobDetailsByFilters(int categoryId = 0);
}
