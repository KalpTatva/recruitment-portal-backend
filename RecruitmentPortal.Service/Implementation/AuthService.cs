using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;
using static RecruitmentPortal.Repository.Helpers.Enums;

namespace RecruitmentPortal.Service.Implementation;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
            // add phone into profile
            Profile profile = new Profile
            {
                Phone = register.phone
            };

            await _unitOfWork.profileRepository.AddAsync(profile);

            // add other values in users
            User user = new User
            {
                Email = register.email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(register.password),
                UserName = register.userName,
                Role = (int)RoleEnum.Candidate,
                ProfileId = profile.ProfileId,

            };
            await _unitOfWork.userRepository.AddAsync(user);

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
}
