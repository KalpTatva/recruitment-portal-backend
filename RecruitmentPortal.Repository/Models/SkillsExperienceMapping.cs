using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class SkillsExperienceMapping
{
    public int SkillsExperienceMappingId { get; set; }

    public int? ExperienceId { get; set; }

    public int? SkillId { get; set; }

    public virtual Experience? Experience { get; set; }

    public virtual Skill? Skill { get; set; }
}
