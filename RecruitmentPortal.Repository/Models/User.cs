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

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ModifiedById { get; set; }

    public int? DeletedById { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<CompanyHistory> CompanyHistories { get; set; } = new List<CompanyHistory>();

    public virtual ICollection<EducationUserMapping> EducationUserMappings { get; set; } = new List<EducationUserMapping>();

    public virtual ICollection<ExperienceUserMapping> ExperienceUserMappings { get; set; } = new List<ExperienceUserMapping>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual ICollection<UsersHistory> UsersHistories { get; set; } = new List<UsersHistory>();
}
