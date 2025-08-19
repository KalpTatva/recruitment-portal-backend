using Microsoft.AspNetCore.Mvc;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;

namespace RecruitmentPortal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel login)
    {
        try
        {
            if (ModelState.IsValid)
            {
                ResponseViewModel<TokensViewModel> response = await _authService.LoginUser(login);
                if (response.Success)
                {
                    return Ok(new ApiResponse<TokensViewModel> { Success = true, Message = response.Message ?? "", Data = response.data, Errors = null });
                }
                return BadRequest(new ApiResponse<string> { Success = false, Message = response?.Message ?? "", Data = null, Errors = null });

            }
            else
            {
                List<string> errorsList = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();

                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Invalid Login credentials.",
                    Data = null,
                    Errors = errorsList
                });
            }

        }
        catch(Exception e)
        {
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"{e.Message}",
                Data = null
            });
        }
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> RegisterCandidate([FromBody] RegisterUserViewModel register)
    {
        try
        {
            if (ModelState.IsValid)
            {
                ResponseViewModel<string> response = await _authService.RegisterNewUser(register);
                if (response.Success)
                {
                    return Ok(new ApiResponse<string> { Success = true, Message = response?.Message ?? "", Data = null, Errors = null });
                }
                return BadRequest(new ApiResponse<string> { Success = false, Message = response?.Message ?? "", Data = null, Errors = null });
            }
            else
            {
                List<string> errorsList = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Invalid Registeration data.",
                    Data = null,
                    Errors = errorsList
                });
            }
        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"{e.Message}",
                Data = null
            });
        }
    }
}
