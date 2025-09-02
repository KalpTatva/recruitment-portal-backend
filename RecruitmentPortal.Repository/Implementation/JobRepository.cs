
using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

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


