using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;

namespace RecruitmentPortal.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost]
    [Route("add-job")]
    public async Task<IActionResult> AddJobs(AddJobsViewModel AddJobs)
    {
        try
        {
            if (ModelState.IsValid)
            {
                string? Email = HttpContext.Items["Email"]?.ToString();

                if (Email == null)
                {
                    return Unauthorized(new { message = "Invalid or missing token" });
                }

                ResponseViewModel<string> responseViewModel = await _jobService.AddJobs(AddJobs, Email);
                if (responseViewModel.Success)
                {
                    return Ok(new ApiResponse<string>
                    {
                        Success = true,
                        Message = responseViewModel.Message ?? "Job added successfully!"
                    });
                }
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = responseViewModel.Message ?? "Failed to retrieve company details.",
                    Data = null,
                    Errors = null
                });
            }
            List<string> errorsList = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = "Invalid job details.",
                Data = null,
                Errors = errorsList
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

    [HttpGet]
    [Route("get-job-categories")]
    public async Task<IActionResult> GetJobCategories()
    {
        try
        {
            return Ok();
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

    [HttpGet]
    [Route("get-job-list")]
    public async Task<IActionResult> GetJobList()
    {
        try
        {
            ResponseViewModel<JobListViewModel> listViewModel = await _jobService.GetJobs();

            if (listViewModel != null && listViewModel.Success)
            {
                return Ok(new ApiResponse<JobListViewModel>
                {
                    Success = true,
                    Message = listViewModel.Message ?? "job lists retrieved successully!",
                    Data = listViewModel.data
                });
            }
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"500 : Failed to load job lists, please try again letter!",
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


    [Route("get-categories-filter")]
    [HttpGet]
    public async Task<IActionResult> GetCategoryFilters()
    {
        try
        {
            ResponseViewModel<CategoryFilterViewModel> categoryResponse = await _jobService.GetCategoryFilters();
            if (categoryResponse.Success)
            {
                return Ok(new ApiResponse<List<CategoryFilterViewModel>>
                {
                    Success = true,
                    Message = categoryResponse.Message ?? "job lists retrieved successully!",
                    Data = categoryResponse.dataList
                });
            }
            return BadRequest(
                new ApiResponse<List<CategoryFilterViewModel>>
                {
                    Success = false,
                    Message = categoryResponse.Message ?? "",
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

    [Route("get-cities")]
    [HttpGet]
    public async Task<IActionResult> GetCityList()
    {
        try
        {
            ResponseViewModel<City> countryResponse = await _jobService.GetCitiesList();
            if (countryResponse.Success)
            {
                return Ok(
                    new ApiResponse<List<City>>
                    {
                        Success = true,
                        Message = countryResponse.Message ?? "",
                        Data = countryResponse.dataList,
                        Errors = null
                    }
                );
            }
            return BadRequest(
                new ApiResponse<string>
                {
                    Success = false,
                    Message = countryResponse.Message ?? "Failed to retrieve cities.",
                    Data = null,
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



    [Route("get-job-type")]
    [HttpGet]
    public async Task<IActionResult> GetJobTypeList()
    {
        try
        {
            ResponseViewModel<JobType> countryResponse = await _jobService.GetJobTypeFilters();
            if (countryResponse.Success)
            {
                return Ok(
                    new ApiResponse<List<JobType>>
                    {
                        Success = true,
                        Message = countryResponse.Message ?? "",
                        Data = countryResponse.dataList,
                        Errors = null
                    }
                );
            }
            return BadRequest(
                new ApiResponse<string>
                {
                    Success = false,
                    Message = countryResponse.Message ?? "Failed to retrieve job types.",
                    Data = null,
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

    

    [HttpGet]
    [Route("get-job-list-with-params")]
    public async Task<IActionResult> GetJobListByParams(
        int categoryId = 0,
        string searchInput = "",
        int location = 0,
        int jobType = 0,
        int experience = 0,
        int datePost = 0,
        int minSalary = 0,
        int maxSalary = 0
    )
    {
        try
        {
            
            ResponseViewModel<JobListViewModel> listViewModel = await _jobService.GetJobsByFilters(categoryId, searchInput, location, jobType, experience, datePost, minSalary, maxSalary);

            if (listViewModel != null && listViewModel.Success)
            {
                return Ok(new ApiResponse<JobListViewModel>
                {
                    Success = true,
                    Message = listViewModel.Message ?? "job lists retrieved successully!",
                    Data = listViewModel.data
                });
            }
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = $"500 : Failed to load job lists, please try again letter!",
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

}
