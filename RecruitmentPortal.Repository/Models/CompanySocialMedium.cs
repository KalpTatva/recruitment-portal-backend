using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class CompanySocialMedium
{
    public int CompanySocialMedia { get; set; }

    public int CompanyId { get; set; }

    public string? LinkedIn { get; set; }

    public string? Twitter { get; set; }

    public string? FaceBook { get; set; }

    public string? Medium { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public virtual Company Company { get; set; } = null!;
}
