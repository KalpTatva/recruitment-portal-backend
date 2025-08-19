using System.ComponentModel.DataAnnotations;

namespace RecruitmentPortal.Repository.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [MaxLength(50, ErrorMessage = "limit exceed ")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is not valid")]
    public string email { get; set; } = string.Empty;

    [Required(ErrorMessage = "password is required")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Atleast contain 1-uppercase, 1-lowercase, 1-special charecter, 1-number  and length should be 8")]
    public string password { get; set; } = string.Empty;

    public bool rememberMe { get; set; }
}
