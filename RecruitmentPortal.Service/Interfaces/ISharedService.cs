using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Service.Interfaces;

public interface ISharedService
{
    Task<ResponseViewModel<Country>> GetCountriesList();
    Task<ResponseViewModel<State>> GetStateListByCountryId(int countryId);
}
