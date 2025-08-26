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


}
