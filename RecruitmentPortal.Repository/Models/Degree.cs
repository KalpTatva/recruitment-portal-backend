using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Degree
{
    public int DegreeId { get; set; }

    public string? Degree1 { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<JobsHistory> JobsHistories { get; set; } = new List<JobsHistory>();
}
