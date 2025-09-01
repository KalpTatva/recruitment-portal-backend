using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class JobRole
{
    public int JobRoleId { get; set; }

    public string JobRole1 { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<JobsHistory> JobsHistories { get; set; } = new List<JobsHistory>();
}
