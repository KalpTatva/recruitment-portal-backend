namespace RecruitmentPortal.Repository.ViewModels;

using System;
using System.ComponentModel.DataAnnotations;

public class AddJobsViewModel
{
    [Required(ErrorMessage = "Job Title is required.")]
    [StringLength(100, ErrorMessage = "Job Title cannot exceed 100 characters.")]
    public string JobTitle { get; set; } = null!;

    [Required(ErrorMessage = "Description is required.")]
    public string? JobDescription { get; set; }

    [Required(ErrorMessage = "Company Location is required.")]
    public int CompanyLocationId { get; set; }

    [Required(ErrorMessage = "Job Category is required.")]
    public int JobCategoryId { get; set; }

    [Required(ErrorMessage = "Job Role is required.")]
    public int JobRoleId { get; set; }

    [Required(ErrorMessage = "Job Type is required.")]
    public int JobTypeId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Experience must be a non-negative integer.")]
    public int Experience { get; set; }

    [StringLength(500, ErrorMessage = "Tags cannot exceed 500 characters.")]
    public string? Tags { get; set; }

    [Required(ErrorMessage = "Degree is required.")]
    public int DegreeId { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Minimum Salary must be a non-negative value.")]
    public decimal? MinSalary { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Maximum Salary must be a non-negative value.")]
    public decimal? MaxSalary { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? ApplicationStartDate { get; set; }

    [DataType(DataType.Date)]
    [DateGreaterThan("ApplicationStartDate", ErrorMessage = "Application End Date must be after the Start Date.")]
    public DateOnly? ApplicationEndDate { get; set; }
}



