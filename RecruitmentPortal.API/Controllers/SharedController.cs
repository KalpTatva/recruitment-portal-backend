using Microsoft.AspNetCore.Mvc;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;

namespace RecruitmentPortal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SharedController : ControllerBase
{
    private readonly ISharedService _sharedService;
    public SharedController(ISharedService sharedService)
    {
        _sharedService = sharedService;
    }

    [Route("get-countries")]
    [HttpGet]
    public async Task<IActionResult> GetCountriesList()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<Country> countryResponse = await _sharedService.GetCountriesList();
            if (!countryResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = countryResponse.Message ?? "Failed to retrieve countries.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<Country>>
                {
                    Success = true,
                    Message = countryResponse.Message ?? "",
                    Data = countryResponse.dataList,
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

    [Route("get-states-by-country/{countryId}")]
    [HttpGet]
    public async Task<IActionResult> GetStateListByCountryId(int countryId)
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<State> stateResponse = await _sharedService.GetStateListByCountryId(countryId);
            if (!stateResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = stateResponse.Message ?? "Failed to retrieve states.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<State>>
                {
                    Success = true,
                    Message = stateResponse.Message ?? "",
                    Data = stateResponse.dataList,
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


    [Route("get-city-by-state/{stateId}")]
    [HttpGet]
    public async Task<IActionResult> GetCityListBystateId(int stateId)
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<City> stateResponse = await _sharedService.GetCityListBystateId(stateId);
            if (!stateResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = stateResponse.Message ?? "Failed to retrieve cities.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<City>>
                {
                    Success = true,
                    Message = stateResponse.Message ?? "",
                    Data = stateResponse.dataList,
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


    

    [Route("get-job-types")]
    [HttpGet]
    public async Task<IActionResult> GetJobTypes()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }
            
            ResponseViewModel<JobType> jobTypeResponse = await _sharedService.GetJobTypeList();
            if (!jobTypeResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = jobTypeResponse.Message ?? "Failed to retrieve jobtypes.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<JobType>>
                {
                    Success = true,
                    Message = jobTypeResponse.Message ?? "",
                    Data = jobTypeResponse.dataList,
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

    [Route("get-job-roles")]
    [HttpGet]
    public async Task<IActionResult> GetJobRoles()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<JobRole> jobRoleResponse = await _sharedService.GetJobRoleList();
            if (!jobRoleResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = jobRoleResponse.Message ?? "Failed to retrieve jobtypes.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<JobRole>>
                {
                    Success = true,
                    Message = jobRoleResponse.Message ?? "",
                    Data = jobRoleResponse.dataList,
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


    [Route("get-degree")]
    [HttpGet]
    public async Task<IActionResult> GetDegree()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<Degree> degreeResponse = await _sharedService.GetAllDegreeType();
            if (!degreeResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = degreeResponse.Message ?? "Failed to retrieve degree.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<Degree>>
                {
                    Success = true,
                    Message = degreeResponse.Message ?? "",
                    Data = degreeResponse.dataList,
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



    [Route("get-job-category")]
    [HttpGet]
    public async Task<IActionResult> GetJobCategory()
    {
        try
        {
            string? Email = HttpContext.Items["Email"]?.ToString();

            if (Email == null)
            {
                return Unauthorized(new { message = "Invalid or missing token" });
            }

            ResponseViewModel<JobCategory> degreeResponse = await _sharedService.GetAllCategories();
            if (!degreeResponse.Success)
            {
                return BadRequest(
                    new ApiResponse<string>
                    {
                        Success = false,
                        Message = degreeResponse.Message ?? "Failed to retrieve categories.",
                        Data = null,
                        Errors = null
                    }
                );
            }
            return Ok(
                new ApiResponse<List<JobCategory>>
                {
                    Success = true,
                    Message = degreeResponse.Message ?? "",
                    Data = degreeResponse.dataList,
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
