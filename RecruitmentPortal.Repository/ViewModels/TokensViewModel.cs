namespace RecruitmentPortal.Repository.ViewModels;

public class TokensViewModel
{
    public string accessToken { get; set; } = string.Empty;
    public string userName { get; set; } = string.Empty;
    public string roleType { get; set; } = string.Empty;
    public bool rememberMe { get; set; }
}
