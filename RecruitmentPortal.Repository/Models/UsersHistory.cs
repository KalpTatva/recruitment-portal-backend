using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class UsersHistory
{
    public int UserHistoryId { get; set; }

    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public int? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedById { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedById { get; set; }

    public string? Operation { get; set; }

    public virtual User User { get; set; } = null!;
}
