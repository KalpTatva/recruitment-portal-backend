using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Service.Interfaces;

public interface IJobService
{
    Task<ResponseViewModel<string>> AddJobs(AddJobsViewModel addJobs, string email);
    Task<ResponseViewModel<JobListViewModel>> GetJobs();
}
