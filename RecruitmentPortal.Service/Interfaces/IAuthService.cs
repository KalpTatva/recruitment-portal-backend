using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Service.Interfaces;

public interface IAuthService
{
    Task<ResponseViewModel<TokensViewModel>> LoginUser(LoginViewModel login);
    Task<ResponseViewModel<string>> RegisterNewUser(RegisterUserViewModel register);
}
