using Azure;
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
            if (states != null)
            {
                return new ResponseViewModel<State>
                {
                    Success = true,
                    Message = "States retrieved successfully.",
                    dataList = states
                };
            }
            return new ResponseViewModel<State>
            {
                Success = false,
                Message = "Error retrieving states"
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

            if (cities != null)
            {
                return new ResponseViewModel<City>
                {
                    Success = true,
                    Message = "cities retrieved successfully.",
                    dataList = cities
                };
            }

            return new ResponseViewModel<City>
            {
                Success = false,
                Message = "Error retrieving cities"
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving cities for state ID {stateId}: {e.Message}");
        }
    }


    public async Task<ResponseViewModel<JobType>> GetJobTypeList()
    {
        try
        {
            List<JobType> jobTypes = await _unitOfWork.jobTypeRepository.GetAllAsync();
            if (jobTypes != null)
            {
                return new ResponseViewModel<JobType>
                {
                    Success = true,
                    Message = "Job types retrieved successfully.",
                    dataList = jobTypes
                };
            }

            return new ResponseViewModel<JobType>
            {
                Success = false,
                Message = "Error retrieving job types"
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving job types : {e.Message}");
        }
    }


    public async Task<ResponseViewModel<JobRole>> GetJobRoleList()
    {
        try
        {
            List<JobRole> jobRole = await _unitOfWork.jobRoleRepository.GetAllAsync();
            if (jobRole != null)
            {
                return new ResponseViewModel<JobRole>
                {
                    Success = true,
                    Message = "Job roles retrieved successfully.",
                    dataList = jobRole
                };
            }

            return new ResponseViewModel<JobRole>
            {
                Success = false,
                Message = "Error retrieving job roles"
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving job types : {e.Message}");
        }
    }

    public async Task<ResponseViewModel<Degree>> GetAllDegreeType()
    {
        try
        {
            List<Degree> degrees = await _unitOfWork.degreeRepository.GetAllAsync();
            if (degrees != null)
            {
                return new ResponseViewModel<Degree>
                {
                    Success = true,
                    Message = "Degree retrieved successfully.",
                    dataList = degrees
                };
            }

            return new ResponseViewModel<Degree>
            {
                Success = false,
                Message = "Error retrieving degree"
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving degrees : {e.Message}");
        }
    }

    public async Task<ResponseViewModel<JobCategory>> GetAllCategories()
    {
        try
        {
            List<JobCategory> jobCategory = await _unitOfWork.jobCategoryRepository.GetAllAsync();
            if (jobCategory != null)
            {
                return new ResponseViewModel<JobCategory>
                {
                    Success = true,
                    Message = "Job category retrieved successfully.",
                    dataList = jobCategory
                };
            }

            return new ResponseViewModel<JobCategory>
            {
                Success = false,
                Message = "Error retrieving job categories"
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving categories : {e.Message}");
        }
    }
    

}
