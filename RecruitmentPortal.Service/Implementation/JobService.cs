using Azure;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;
using static RecruitmentPortal.Repository.Helpers.Enums;

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


    public async Task<ResponseViewModel<JobListViewModel>> GetJobsByFilters(
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
    )
    {
        try
        {
            JobListViewModel? jobs = await _unitOfWork.jobRepository.GetJobDetailsByFilters(
                categoryId, searchInput, location, jobType, experience, datePost, minSalary, maxSalary, sorting, pageNumber, pageSize
            );

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

    public async Task<ResponseViewModel<City>> GetCitiesList()
    {
        try
        {
            return new ResponseViewModel<City>
            {
                Success = true,
                Message = "Countries retrieved successfully.",
                dataList = await _unitOfWork.cityRepository.GetAllAsync()
            };

        }
        catch (Exception e)
        {
            throw new Exception($"Error in retrieving cities: {e.Message}");
        }
    }


    public async Task<ResponseViewModel<CategoryFilterViewModel>> GetCategoryFilters()
    {
        try
        {
            List<CategoryFilterViewModel> category = await _unitOfWork.jobCategoryRepository.GetCategoryFilters();
            return new ResponseViewModel<CategoryFilterViewModel>
            {
                Success = true,
                Message = "Categories retrived successfully.",
                dataList = category
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error in retrieving category filters: {e.Message}");
        }
    }


    public async Task<ResponseViewModel<JobType>> GetJobTypeFilters()
    {
        try
        {
            List<JobType> jobTypes = await _unitOfWork.jobTypeRepository.GetAllAsync();
            return new ResponseViewModel<JobType>
            {
                Success = true,
                Message = "Job types retrived successfully.",
                dataList = jobTypes
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error in retrieving job type filters: {e.Message}");
        }
    }

    public async Task<ResponseViewModel<JobDetailsViewModel>> GetJobDetails(int jobId)
    {
        try
        {
            JobDetailsViewModel? jobDetail = await _unitOfWork.jobRepository.GetJobDetailsById(jobId);


            return new ResponseViewModel<JobDetailsViewModel>
            {
                Success = true,
                Message = "Job details retrived successfully.",
                data = jobDetail ?? new JobDetailsViewModel(),
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error in retrieving job type filters: {e.Message}");
        }
    }
}
