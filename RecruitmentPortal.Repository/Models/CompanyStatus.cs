using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class CompanyStatus
{
    public int CompanyStatusId { get; set; }

    public int CompanyId { get; set; }

    public int? CompanyFoundedYear { get; set; }

    public string? IndustryType { get; set; }

    public int? NumberOfFounders { get; set; }

    public int? TotalEmployees { get; set; }

    public int? TotalMaleEmployees { get; set; }

    public int? TotalFemaleEmployees { get; set; }

    public int? TotalOtherEmployees { get; set; }

    public decimal? TotalRevenue { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public virtual Company Company { get; set; } = null!;
}
