using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class State
{
    public int StateId { get; set; }

    public int? CountryId { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<CompanyLocation> CompanyLocations { get; set; } = new List<CompanyLocation>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
