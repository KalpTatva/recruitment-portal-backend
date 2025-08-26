using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;

namespace RecruitmentPortal.Service.Implementation;

public class SharedService : ISharedService
{
    private readonly IUnitOfWork _unitOfWork;
    public SharedService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseViewModel<Country>> GetCountriesList()
    {
        try
        {
            return new ResponseViewModel<Country>
            {
                Success = true,
                Message = "Countries retrieved successfully.",
                dataList = await _unitOfWork.countryRepository.GetAllAsync()
            };

        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving countries: {e.Message}");
        }
    }

    public async Task<ResponseViewModel<State>> GetStateListByCountryId(int countryId)
    {
        try
        {
            List<State> states = await _unitOfWork.stateRepository.GetAllListByIdAsync(s => s.CountryId == countryId);
            return new ResponseViewModel<State>
            {
                Success = true,
                Message = "States retrieved successfully.",
                dataList = states
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving states for country ID {countryId}: {e.Message}");
        }
    }

    public async Task<ResponseViewModel<City>> GetCityListBystateId(int stateId)
    {
        try
        {
            List<City> cities = await _unitOfWork.cityRepository.GetAllListByIdAsync(x => x.StateId == stateId);
            return new ResponseViewModel<City>
            {
                Success = true,
                Message = "cities retrieved successfully.",
                dataList = cities
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving cities for state ID {stateId}: {e.Message}");
        }
    }
    

}
