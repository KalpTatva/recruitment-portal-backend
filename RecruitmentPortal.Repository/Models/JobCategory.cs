using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class JobCategory
{
    public int JobCategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<JobsHistory> JobsHistories { get; set; } = new List<JobsHistory>();
}
