using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    [Route("add-job")]
    public async Task<IActionResult> AddJobs()
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

}
