namespace RecruitmentPortal.Repository.ViewModels;

public class AddJobsViewModel
{
    public string JobTitle { get; set; } = null!;

    public string? JobDescription { get; set; }

    public int CompanyLocationId { get; set; }

    public int JobCategoryId { get; set; }

    public int JobRoleId { get; set; }

    public int JobTypeId { get; set; }

    public int Experience { get; set; }

    public string? Tags { get; set; }

    public int DegreeId { get; set; }

    public decimal? MinSalary { get; set; }

    public decimal? MaxSalary { get; set; }

    public DateOnly? ApplicationStartDate { get; set; }

    public DateOnly? ApllicationEndDate { get; set; }

}
