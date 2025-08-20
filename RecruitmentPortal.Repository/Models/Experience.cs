using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Experience
{
    public int ExperienceId { get; set; }

    public string Title { get; set; } = null!;

    public int EmployeementType { get; set; }

    public string? CompanyName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? LocationAddress { get; set; }

    public int? LocationType { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<ExperienceUserMapping> ExperienceUserMappings { get; set; } = new List<ExperienceUserMapping>();

    public virtual ICollection<SkillsExperienceMapping> SkillsExperienceMappings { get; set; } = new List<SkillsExperienceMapping>();
}
