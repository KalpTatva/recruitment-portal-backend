using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public virtual ICollection<SkillsExperienceMapping> SkillsExperienceMappings { get; set; } = new List<SkillsExperienceMapping>();
}
