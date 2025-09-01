using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Interfaces;

public interface ICompanyLocationRepository : IGenericRepository<Models.CompanyLocation>
{
    Task<List<CompanyLocationWithNameForProfileViewModel>> GetCompanyLocations(int userId);
}
