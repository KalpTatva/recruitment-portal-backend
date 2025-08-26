using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class CompanyHistory
{
    public int CompanyHistoryId { get; set; }

    public int CompanyId { get; set; }

    public int UserId { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyType { get; set; }

    public string? CompanyWebsite { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? CountryCode { get; set; }

    public long? Phone { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedById { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedById { get; set; }

    public string? Operation { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
