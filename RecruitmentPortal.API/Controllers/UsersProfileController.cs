using Microsoft.AspNetCore.Mvc;

namespace RecruitmentPortal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersProfileController : ControllerBase
{

    public UsersProfileController()
    {
        
    }

    [Route("get-company-profile")]
    [HttpGet]
    public IActionResult GetCompanyProfile(string email)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new { Success = false, Message = e.Message });
        }
    }
}
