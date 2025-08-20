using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<SkillsExperienceMapping> SkillsExperienceMappings { get; set; } = new List<SkillsExperienceMapping>();
}
