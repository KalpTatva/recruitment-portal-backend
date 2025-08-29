using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class CompanyLocation
{
    public int CompanyLocationId { get; set; }

    public int CompanyId { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public string Address { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<CompanyLocationsHistory> CompanyLocationsHistories { get; set; } = new List<CompanyLocationsHistory>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<JobsHistory> JobsHistories { get; set; } = new List<JobsHistory>();

    public virtual State State { get; set; } = null!;
}
