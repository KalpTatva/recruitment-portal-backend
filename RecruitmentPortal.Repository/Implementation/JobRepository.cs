
using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using static RecruitmentPortal.Repository.Helpers.Enums;

namespace RecruitmentPortal.Repository.Implementation;

public class JobRepository : GenericRepository<Job>, IJobRepository
{
    private readonly RecruitmentPortalContext _context;
    public JobRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ListOfJobsViewModel>> GetJobDetails()
    {
        try
        {
            List<ListOfJobsViewModel> lists = await _context.Jobs.Select(x => new ListOfJobsViewModel
            {
                ImageUrl = x.Company.ImageUrl,
                CompanyName = x.Company.CompanyName,
                JobRole = x.JobRole.JobRole1,
                JobType = x.JobType.JobType1,
                JobCategory = x.JobCategory.CategoryName,
                JobTitle = x.JobTitle,
                Address = $"{x.CompanyLocation.State.StateName}, {x.CompanyLocation.Country.CountryName}",
                MinSalary = x.MinSalary ?? 0,
                MaxSalary = x.MaxSalary ?? 0,
                ApplicationStartDate = x.ApplicationStartDate,
                ApplicationEndDate = x.ApllicationEndDate,
                Experience = x.Experience,
                CreatedAt = GetTimestamp(x.CreatedAt)
            }).ToListAsync();

            return lists;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<JobDetailsViewModel> GetJobDetailsById(int jobId)
    {
        try
        {
            JobDetailsViewModel? details = await _context.Jobs
            .Where(x => x.JobId == jobId)
            .Select(x => new JobDetailsViewModel
            {
                JobId = x.JobId,
                ImageUrl = x.Company.ImageUrl,
                CompanyName = x.Company.CompanyName,
                JobTitle = x.JobTitle,
                JobRole = x.JobRole.JobRole1,
                JobType = x.JobType.JobType1,
                JobCategory = x.JobCategory.CategoryName,
                JobDescription = x.JobDescription,
                ShortAddress = $"{x.CompanyLocation.State.StateName}, {x.CompanyLocation.Country.CountryName}",
                LongAddress = $"{x.CompanyLocation.Address}, {x.CompanyLocation.City.CityName}, {x.CompanyLocation.State.StateName}, {x.CompanyLocation.Country.CountryName}",
                MinSalary = x.MinSalary ?? 0,
                MaxSalary = x.MaxSalary ?? 0,

                ApplicationStartDate = x.ApplicationStartDate,
                ApplicationEndDate = x.ApllicationEndDate,
                Experience = x.Experience,
                Degree = x.Degree.Degree1,
                CreatedAt = GetTimestamp(x.CreatedAt),
                Tags = x.Tags

            }).FirstOrDefaultAsync();

            return details ?? new JobDetailsViewModel();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<JobListViewModel> GetJobDetailsByFilters(
        int categoryId = 0,
        string searchInput = "",
        int location = 0,
        int jobType = 0,
        int experience = 0,
        int datePost = 0,
        int minSalary = 0,
        int maxSalary = 0,
        int sorting = (int)SortingEnum.SortByLatest,
        int pageNumber = 0,
        int pageSize = 6
    )
    {
        try
        {
            IQueryable<Job>? query = _context.Jobs.AsQueryable();
            query = query.Where(x => x.IsDeleted == false);
            // category ids
            if (categoryId > 0)
            {
                query = query.Where(x => x.JobCategoryId == categoryId);
            }
            // search inputs (company name / job title)
            if (!string.IsNullOrWhiteSpace(searchInput))
            {
                query = query.Where(x =>
                    x.JobTitle.Contains(searchInput) ||
                    x.Company.CompanyName.Contains(searchInput));
            }
            // locations
            if (location > 0)
            {
                query = query.Where(x => x.CompanyLocation.CityId == location && x.CompanyLocation.IsDeleted == false);
            }
            // job types
            if (jobType > 0)
            {
                query = query.Where(x => x.JobTypeId == jobType);
            }
            // experience
            if (experience > 0)
            {
                query = query.Where(x => x.Experience >= experience);
            }
            // date 
            if (datePost > 0)
            {
                DateTime now = DateTime.UtcNow;
                switch (datePost)
                {
                    case 2: // Last Hour
                        query = query.Where(x => x.CreatedAt >= now.AddHours(-1));
                        break;
                    case 3: // Last 24 Hours
                        query = query.Where(x => x.CreatedAt >= now.AddDays(-1));
                        break;
                    case 4: // Last 7 Days
                        query = query.Where(x => x.CreatedAt >= now.AddDays(-7));
                        break;
                    case 5: // Last 30 Days
                        query = query.Where(x => x.CreatedAt >= now.AddDays(-30));
                        break;
                }
            }
            // salary 
            if (maxSalary > 0 && maxSalary > minSalary)
            {
                query = query.Where(x => x.MaxSalary <= maxSalary && x.MinSalary >= minSalary);
            }
            // sortings 

            query = sorting > 0 ?
                    sorting == (int)SortingEnum.SortByLatest ? query.OrderByDescending(x => x.CreatedAt) :
                    sorting == (int)SortingEnum.SortByOldest ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt)
                    : query.OrderByDescending(x => x.CreatedAt);

            List<ListOfJobsViewModel> list = await query.Select(x => new ListOfJobsViewModel
            {
                JobId = x.JobId,
                ImageUrl = x.Company.ImageUrl,
                CompanyName = x.Company.CompanyName,
                JobRole = x.JobRole.JobRole1,
                JobType = x.JobType.JobType1,
                JobCategory = x.JobCategory.CategoryName,
                JobTitle = x.JobTitle,
                Address = $"{x.CompanyLocation.State.StateName}, {x.CompanyLocation.Country.CountryName}",
                MinSalary = x.MinSalary ?? 0,
                MaxSalary = x.MaxSalary ?? 0,
                ApplicationStartDate = x.ApplicationStartDate,
                ApplicationEndDate = x.ApllicationEndDate,
                Experience = x.Experience,
                CreatedAt = GetTimestamp(x.CreatedAt)
            })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            // total jobs based on filters 
            int totalJobs = await query.CountAsync();

            return new JobListViewModel
            {
                JobList = list,
                totalJobs = totalJobs,
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


    private static string GetTimestamp(DateTime? createdAt)
    {
        if (createdAt != null)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan timeDifference = currentDate - createdAt.Value;

            if (timeDifference.TotalMinutes < 60)
            {
                return $"{(int)timeDifference.TotalMinutes} min ago";
            }
            else if (timeDifference.TotalHours < 24)
            {
                return $"{(int)timeDifference.TotalHours} hr ago";
            }
            else if (timeDifference.TotalDays < 365)
            {
                return $"{(int)timeDifference.TotalDays} days ago";
            }
            else
            {
                return $"{(int)(timeDifference.TotalDays / 365)} years ago";
            }
        }
        return "Unknown";
    }
}



























// public async Task<List<ListOfJobsViewModel>> GetJobDetails()
// {
//     try
//     {
//         List<ListOfJobsViewModel> lists = await _context.Jobs.Select(x => new ListOfJobsViewModel
//         {
//             ImageUrl = x.Company.ImageUrl,
//             CompanyName = x.Company.CompanyName,
//             JobRole = x.JobRole.JobRole1,
//             JobType = x.JobType.JobType1,
//             JobCategory = x.JobCategory.CategoryName,
//             JobTitle = x.JobTitle,
//             Address = $"{x.CompanyLocation.State.StateName}, {x.CompanyLocation.Country.CountryName}",
//             MinSalary = x.MinSalary ?? 0,
//             MaxSalary = x.MaxSalary ?? 0,
//             ApplicationStartDate = x.ApplicationStartDate,
//             ApplicationEndDate = x.ApplicationEndDate,
//             Experience = x.Experience,
//             CreatedAt = GetTimestamp(x.CreatedAt)
//         }).ToListAsync();

//         return lists;
//     }
//     catch (Exception e)
//     {
//         throw new Exception(e.Message);
//     }
// }

// private static string GetTimestamp(DateTime? createdAt)
// {
//     if (createdAt != null)
//     {
//         DateTime currentDate = DateTime.Now;
//         TimeSpan timeDifference = currentDate - createdAt.Value;

//         if (timeDifference.TotalMinutes < 60)
//         {
//             return $"{(int)timeDifference.TotalMinutes} min ago";
//         }
//         else if (timeDifference.TotalHours < 24)
//         {
//             return $"{(int)timeDifference.TotalHours} hr ago";
//         }
//         else if (timeDifference.TotalDays < 365)
//         {
//             return $"{(int)timeDifference.TotalDays} days ago";
//         }
//         else
//         {
//             return $"{(int)(timeDifference.TotalDays / 365)} years ago";
//         }
//     }
//     return "Unknown";
// }


