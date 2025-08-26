using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class City
{
    public int CityId { get; set; }

    public int? StateId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<CompanyLocation> CompanyLocations { get; set; } = new List<CompanyLocation>();

    public virtual ICollection<CompanyLocationsHistory> CompanyLocationsHistories { get; set; } = new List<CompanyLocationsHistory>();

    public virtual ICollection<ProfileHistory> ProfileHistories { get; set; } = new List<ProfileHistory>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual State? State { get; set; }
}
