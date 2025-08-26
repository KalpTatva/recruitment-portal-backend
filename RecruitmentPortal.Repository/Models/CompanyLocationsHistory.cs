using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class CompanyLocationsHistory
{
    public int CompanyLocationHistoryId { get; set; }

    public int CompanyLocationId { get; set; }

    public int CompanyId { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public string? Address { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedById { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedById { get; set; }

    public string? Operation { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual CompanyLocation CompanyLocation { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual State State { get; set; } = null!;
}
