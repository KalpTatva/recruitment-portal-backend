using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Education
{
    public int EducationId { get; set; }

    public string School { get; set; } = null!;

    public string? Degree { get; set; }

    public string? FeildOfStudy { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Grade { get; set; }

    public string? Activities { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public int? CreatedById { get; set; }

    public virtual ICollection<EducationUserMapping> EducationUserMappings { get; set; } = new List<EducationUserMapping>();
}
