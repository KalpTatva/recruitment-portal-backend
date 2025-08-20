using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class ExperienceUserMapping
{
    public int ExperienceUserMappingId { get; set; }

    public int? UserId { get; set; }

    public int? ExperienceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Experience? Experience { get; set; }

    public virtual User? User { get; set; }
}
