using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Repository.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int Gender { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public long Phone { get; set; }

    public long? Pincode { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual State? State { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
