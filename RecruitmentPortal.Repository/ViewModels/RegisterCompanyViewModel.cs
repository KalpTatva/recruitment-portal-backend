using System.ComponentModel.DataAnnotations;

namespace RecruitmentPortal.Repository.ViewModels;

public class RegisterCompanyViewModel
{
    [Required(ErrorMessage = "Email is required.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string email { get; set; } = string.Empty;

    [Required(ErrorMessage = "User name is required.")]
    [RegularExpression(@"^[a-zA-Z0-9@%\.,'""\s]+$", ErrorMessage = "User name can only contain letters, numbers, and spaces.")]
    public string userName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid phone number, should be exactly 10 digits.")]
    public long phone { get; set; }

    [Required(ErrorMessage = "Country code is required.")]
    public string countryCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Company name is required.")]
    public string companyName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Company type is required.")]
    public string CompanyType { get; set; } = string.Empty;

    [Required(ErrorMessage = "Company description is required.")]
    [StringLength(500, ErrorMessage = "Company description cannot be longer than 500 characters.")]
    public string companyDescription { get; set; } = string.Empty;

    [Required(ErrorMessage = "Company website is required.")]
    [RegularExpression(@"^(https?://)?(www\.)?[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(/.*)?$", ErrorMessage = "Invalid website URL format.")]
    public string companyWebsite { get; set; } = string.Empty;

    [Required(ErrorMessage = "Company location is required.")]
    public string companyLocation { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,100}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
    public string password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare("password", ErrorMessage = "Passwords do not match.")]
    public string confirmPassword { get; set; } = string.Empty;
}
