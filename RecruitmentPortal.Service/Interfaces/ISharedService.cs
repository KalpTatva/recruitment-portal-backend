using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Service.Interfaces;

public interface ISharedService
{
    Task<ResponseViewModel<Country>> GetCountriesList();
    Task<ResponseViewModel<State>> GetStateListByCountryId(int countryId);
    Task<ResponseViewModel<City>> GetCityListBystateId(int stateId);
    Task<ResponseViewModel<JobType>> GetJobTypeList();
    Task<ResponseViewModel<JobRole>> GetJobRoleList();
    Task<ResponseViewModel<Degree>> GetAllDegreeType();
    Task<ResponseViewModel<JobCategory>> GetAllCategories();

}
