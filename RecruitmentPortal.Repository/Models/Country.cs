using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
