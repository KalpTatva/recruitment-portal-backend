using Azure;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;

namespace RecruitmentPortal.Service.Implementation;

public class JobService : IJobService
{
    private readonly IUnitOfWork _unitOfWork;

    public JobService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<ResponseViewModel<JobListViewModel>> GetJobs()
    {
        try
        {
            JobListViewModel jobs = new();
            List<ListOfJobsViewModel>? jobList = await _unitOfWork.jobRepository.GetJobDetails();
            jobs.JobList = jobList;

            return new ResponseViewModel<JobListViewModel>
            {
                Success = true,
                data = jobs,
                Message = "jobs data retrived successfully!"
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<ResponseViewModel<string>> AddJobs(AddJobsViewModel addJobs, string email)
    {
        try
        {
            User? user = await _unitOfWork.userRepository.FindAsync(x => x.Email == email.Trim().ToLower());
            if (user == null)
            {
                throw new Exception("User not found, invalid token! please try again latter");
            }
            Company? company = await _unitOfWork.companyRepository.FindAsync(x => x.UserId == user.UserId);
            if (company == null)
            {
                throw new Exception("Company not found, invalid token please try again latter");
            }


            DateOnly startDateOnly = addJobs.ApplicationStartDate ?? new DateOnly();
            DateOnly endDateOnly = addJobs.ApplicationEndDate ?? new DateOnly();
            // Create a TimeOnly instance for the desired time (e.g., 10:00 AM)
            TimeOnly time = new TimeOnly(0, 0, 0);

            DateTime startDate = startDateOnly.ToDateTime(time);
            DateTime endDate = endDateOnly.ToDateTime(time);

            Job job = new Job
            {
                CompanyId = company.CompanyId,
                CompanyLocationId = addJobs.CompanyLocationId,
                JobCategoryId = addJobs.JobCategoryId,
                JobTitle = addJobs.JobTitle,
                JobDescription = addJobs.JobDescription,
                Tags = addJobs.Tags,
                MinSalary = addJobs.MinSalary,
                MaxSalary = addJobs.MaxSalary,
                ApplicationStartDate = startDate,
                ApllicationEndDate = endDate,
                CreatedById = user.UserId,
                JobRoleId = addJobs.JobRoleId,
                JobTypeId = addJobs.JobTypeId,
                Experience = addJobs.Experience,
                DegreeId = addJobs.DegreeId,
            };

            await _unitOfWork.jobRepository.AddAsync(job);

            return new ResponseViewModel<string>
            {
                Success = true,
                Message = "Job added successfully!"
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
