using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class JobsHistory
{
    public int JobHistoryId { get; set; }

    public int JobId { get; set; }

    public int CompanyId { get; set; }

    public int CompanyLocationId { get; set; }

    public int JobCategoryId { get; set; }

    public string JobTitle { get; set; } = null!;

    public string? JobDescription { get; set; }

    public string? Tags { get; set; }

    public decimal? MinSalary { get; set; }

    public decimal? MaxSalary { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApllicationEndDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedById { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedById { get; set; }

    public int JobRoleId { get; set; }

    public int JobTypeId { get; set; }

    public int Experience { get; set; }

    public int DegreeId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual CompanyLocation CompanyLocation { get; set; } = null!;

    public virtual Degree Degree { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;

    public virtual JobCategory JobCategory { get; set; } = null!;

    public virtual JobRole JobRole { get; set; } = null!;

    public virtual JobType JobType { get; set; } = null!;
}
