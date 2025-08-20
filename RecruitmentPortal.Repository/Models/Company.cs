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

    public virtual User User { get; set; } = null!;
}
