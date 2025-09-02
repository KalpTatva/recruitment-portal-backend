using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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

}
