using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Role { get; set; }

    public string Password { get; set; } = null!;

    public int ProfileId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public virtual ICollection<EducationUserMapping> EducationUserMappings { get; set; } = new List<EducationUserMapping>();

    public virtual ICollection<ExperienceUserMapping> ExperienceUserMappings { get; set; } = new List<ExperienceUserMapping>();

    public virtual Profile Profile { get; set; } = null!;
}
