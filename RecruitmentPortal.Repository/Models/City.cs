using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class City
{
    public int CityId { get; set; }

    public int? StateId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual State? State { get; set; }
}
