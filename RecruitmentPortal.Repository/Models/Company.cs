using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public int UserId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyType { get; set; } = null!;

    public string CompanyWebsite { get; set; } = null!;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public long? Phone { get; set; }

    public string? ImageUrl { get; set; }

    public string CountryCode { get; set; } = null!;

    public virtual ICollection<CompanyHistory> CompanyHistories { get; set; } = new List<CompanyHistory>();

    public virtual ICollection<CompanyLocation> CompanyLocations { get; set; } = new List<CompanyLocation>();

    public virtual ICollection<CompanyLocationsHistory> CompanyLocationsHistories { get; set; } = new List<CompanyLocationsHistory>();

    public virtual ICollection<CompanySocialMedium> CompanySocialMedia { get; set; } = new List<CompanySocialMedium>();

    public virtual ICollection<CompanyStatusHistory> CompanyStatusHistories { get; set; } = new List<CompanyStatusHistory>();

    public virtual ICollection<CompanyStatus> CompanyStatuses { get; set; } = new List<CompanyStatus>();

    public virtual User User { get; set; } = null!;
}
