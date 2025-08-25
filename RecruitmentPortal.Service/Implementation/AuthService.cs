using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Helpers;
using RecruitmentPortal.Service.Interfaces;
using static RecruitmentPortal.Repository.Helpers.Enums;

namespace RecruitmentPortal.Service.Implementation;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtTokenHelper _jwtHelper;

    public AuthService(IUnitOfWork unitOfWork, JwtTokenHelper jwtHelper)
    {
        _unitOfWork = unitOfWork;
        _jwtHelper = jwtHelper;

    }



    public async Task<ResponseViewModel<TokensViewModel>> LoginUser(LoginViewModel login)
    {
        try
        {
            // checking for availability of user
            User? user = await _unitOfWork.userRepository.FindAsync(x => x.Email == login.email.Trim().ToLower());
            // checing if passwords are matching or not 
            if (user != null && BCrypt.Net.BCrypt.EnhancedVerify(login.password, user.Password))
            {
                // getting role name based on role id
                string? userRole = user != null && user.Role != 0 ? ((RoleEnum)user.Role).ToString() : null;
                // geting users expire time
                DateTime tokenExpire = login.rememberMe == true ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddDays(1);
                // generating access token
                string jwtToken = _jwtHelper.GenerateJwtToken(login.email, tokenExpire, userRole ?? "", user?.UserName ?? "");

                return new ResponseViewModel<TokensViewModel>
                {
                    Success = true,
                    Message = "user logged in successfully",
                    data = new TokensViewModel
                    {
                        accessToken = jwtToken,
                        userName = user?.UserName ?? "",
                        roleType = userRole ?? "",
                        rememberMe = login.rememberMe == true ? true : false
                    },
                };
            }

            return new ResponseViewModel<TokensViewModel>
            {
                Success = false,
                Message = "Invalid user credentials!",
                data = null
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }






    public async Task<ResponseViewModel<string>> RegisterNewUser(RegisterUserViewModel register)
    {
        try
        {

            // need to check if email already exists or not
            User? userByEmail = await _unitOfWork.userRepository.FindAsync(x => x.Email == register.email.Trim().ToLower());
            if (userByEmail != null)
            {
                throw new Exception("Email address already exists! please try another one!");
            }
            // need to check if username already exists or not
            User? userByUserName = await _unitOfWork.userRepository.FindAsync(x => x.UserName == register.userName);
            if (userByUserName != null)
            {
                throw new Exception("Username already exists! please try another one!");
            }
            // need to check if phone already exists or not 
            Profile? profileByPhone = await _unitOfWork.profileRepository.FindAsync(x => x.Phone == register.phone);
            if (profileByPhone != null)
            {
                throw new Exception("Phone already exists! please try another one!");
            }

            // add other values in users
            User user = new User
            {
                Email = register.email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(register.password),
                UserName = register.userName,
                Role = (int)RoleEnum.Candidate

            };
            await _unitOfWork.userRepository.AddAsync(user);

            // add phone into profile
            Profile profile = new Profile
            {
                Phone = register.phone,
                CountryCode = register.countryCode,
                UserId = user.UserId
            };

            await _unitOfWork.profileRepository.AddAsync(profile);

            return new ResponseViewModel<string>
            {
                Success = true,
                Message = "New user registered successfully!"
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }






    public async Task<ResponseViewModel<string>> RegisterNewCompany(RegisterCompanyViewModel company)
    {
        try
        {
            // need to check if email already exists or not
            User? userByEmail = await _unitOfWork.userRepository.FindAsync(x => x.Email == company.email.Trim().ToLower());
            if (userByEmail != null)
            {
                throw new Exception("Email address already exists! please try another one!");
            }
            // need to check if username already exists or not
            User? userByUserName = await _unitOfWork.userRepository.FindAsync(x => x.UserName == company.userName);
            if (userByUserName != null)
            {
                throw new Exception("Username already exists! please try another one!");
            }
            // need to check if phone already exists or not 
            Company? companyByPhone = await _unitOfWork.companyRepository.FindAsync(x => x.Phone == company.phone);
            if (companyByPhone != null)
            {
                throw new Exception("Phone already exists! please try another one!");
            }


            // add other values in users
            User user = new User
            {
                Email = company.email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(company.password),
                UserName = company.userName,
                Role = (int)RoleEnum.Admin,
            };
            await _unitOfWork.userRepository.AddAsync(user);
        
            // add other values in companies
            Company newCompany = new Company
            {
                Phone = company.phone,
                UserId = user.UserId,
                CompanyName = company.companyName,
                CountryCode = company.countryCode,
                CompanyType = company.CompanyType,
                Description = company.companyDescription,
                CompanyWebsite = company.companyWebsite,
                Location = company.companyLocation,
                CreatedById = user.UserId
            };
            await _unitOfWork.companyRepository.AddAsync(newCompany);

            return new ResponseViewModel<string>
            {
                Success = true,
                Message = "New company registered successfully!"
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
