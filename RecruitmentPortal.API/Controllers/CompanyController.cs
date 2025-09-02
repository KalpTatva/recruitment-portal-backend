using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;
namespace RecruitmentPortal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyServices;

    public CompanyController(ICompanyService companyServices)
    {
        _companyServices = companyServices;
    }

    [Route("get-company-details-by-email")]
    [HttpGet]
    public async Task<IActionResult> GetCompanyDetailsByEmail()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<CompanyDetailsViewModel> companyResponse = await _companyServices.GetCompanyDetailsByEmail(Email);
            if (!companyResponse.Success)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = companyResponse.Message ?? "Failed to retrieve company details.",
                    Data = null,
                    Errors = null
                });
            }
            return Ok(new ApiResponse<CompanyDetailsViewModel>
            {
                Success = true,
                Message = companyResponse.Message ?? "",
                Data = companyResponse.data,
                Errors = null
            });

        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"500 : Error occured, {e.Message}",
                Data = null
            });
        }
    }

    [Route("get-company-profile-details-by-email")]
    [HttpGet]
    public async Task<IActionResult> GetCompanyProfileDetailsByEmail()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<CompanyDetailsForProfileViewModel> companyResponse = await _companyServices.GetCompanyDetailsByEmailForProfile(Email);
            if (!companyResponse.Success)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = companyResponse.Message ?? "Failed to retrieve company profile details.",
                    Data = null,
                    Errors = null
                });
            }

            // companyResponse.data.ImageUrl = $"{Request.Scheme}://{Request.Host}{companyResponse.data.ImageUrl}" ?? "";
            return Ok(new ApiResponse<CompanyDetailsForProfileViewModel>
            {
                Success = true,
                Message = companyResponse.Message ?? "",
                Data = companyResponse.data,
                Errors = null
            });

        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"500 : Error occured, {e.Message}",
                Data = null
            });
        }
    }

    [Route("edit-company-details")]
    [HttpPut]
    public async Task<IActionResult> EditCompanyDetails(CompanyDetailsViewModel model)
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            if (ModelState.IsValid)
            {
                ResponseViewModel<string> response = await _companyServices.EditCompanyDetails(model);
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
                    Message = "Invalid Company Details data.",
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
                Message = $"500 : Error occured, {e.Message}",
                Data = null
            });
        }
    }


    [Route("upload-company-logo")]
    [HttpPost]
    public async Task<IActionResult> UploadCompanyImageLogo(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = $"No file uploaded.",
                    Data = null
                });
            }

            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            string requestUrl = $"{Request.Scheme}://{Request.Host}";

            ResponseViewModel<string> response = await _companyServices.UploadCompanyLogo(file, Email, requestUrl);
            if (response.Success)
            {
                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = response?.Message ?? "",
                    Data = response?.data ?? "",
                    Errors = null
                });
            }

            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"No file uploaded.",
                Data = null
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"500 : Error occured, {e.Message}",
                Data = null
            });
        }
    }

    [Route("get-company-locations")]
    [HttpGet]
    public async Task<IActionResult> GetCompanyLocations()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<CompanyLocationWithNameForProfileViewModel> companyLocationsResponse = await _companyServices.GetCompanyLocationsByEmail(Email);
            if (!companyLocationsResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = companyLocationsResponse.Message ?? "Failed to retrieve company locations.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<CompanyLocationWithNameForProfileViewModel>>
                {
                    Success = true,
                    Message = companyLocationsResponse.Message ?? "",
                    Data = companyLocationsResponse.dataList,
                    Errors = null
                }
            );
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
