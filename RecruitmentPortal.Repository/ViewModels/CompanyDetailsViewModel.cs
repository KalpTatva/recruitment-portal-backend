using System.ComponentModel.DataAnnotations;

namespace RecruitmentPortal.Repository.ViewModels;

public class CompanyDetailsViewModel
{
    public int UserId { get; set; }
    public int CompanyId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public long Phone { get; set; }
    public string? countryCode { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;

    public string CompanyType { get; set; } = string.Empty;

    public string CompanyDescription { get; set; } = string.Empty;

    public string CompanyWebsite { get; set; } = string.Empty;

    public string CompanyLocation { get; set; } = string.Empty;

    public int CompanyFoundedYear { get; set; }

    public string IndustryType { get; set; } = string.Empty;

    public int NumberOfFounders { get; set; }

    public int TotalEmployees { get; set; }

    public int TotalMaleEmployees { get; set; }

    public int TotalFemaleEmployees { get; set; }

    public int TotalOthersEmployees { get; set; }
    public decimal TotalRevenue { get; set; }

    public string LinkedIn { get; set; } = string.Empty;
    public string Twitter { get; set; } = string.Empty;
    public string Facebook { get; set; } = string.Empty;
    public string Medium { get; set; } = string.Empty;
    public List<CompanyLocation> CompanyLocations { get; set; } = [];
    
}
public class CompanyLocation
{
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string Address { get; set; } = string.Empty;
}
