namespace RecruitmentPortal.Repository.ViewModels;

public class JobListViewModel
{
    public List<ListOfJobsViewModel>? JobList { get; set; }

}   


public class ListOfJobsViewModel
{
    public string? ImageUrl { get; set; }
    public string? CompanyName { get; set; }
    public string? JobTitle { get; set; }
    public string? JobRole { get; set; }
    public string? JobType { get; set; }
    public string? JobCategory { get; set; }
    public string? Address { get; set; }
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
    public DateTime? ApplicationStartDate { get; set; }
    public DateTime? ApplicationEndDate { get; set; }
    public int Experience { get; set; }
    public string? CreatedAt { get; set; }
} 




/*

img url
job title 
company name 
job role
job type
salry min-max
address
job category
created at



filters:

search job title
location => city vise
job category
job type
Experience level
created at
salary scroller
tags => in future 

*/