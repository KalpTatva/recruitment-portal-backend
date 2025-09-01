using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class JobType
{
    public int JobTypeId { get; set; }

    public string JobType1 { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<JobsHistory> JobsHistories { get; set; } = new List<JobsHistory>();
}
