using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class EducationUserMapping
{
    public int EducationUserMappingId { get; set; }

    public int? UserId { get; set; }

    public int? EducationId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public virtual Education? Education { get; set; }

    public virtual User? User { get; set; }
}
