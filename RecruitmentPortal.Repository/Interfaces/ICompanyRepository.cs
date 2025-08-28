using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Interfaces;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<CompanyDetailsViewModel> GetCompanyDetailsByEmail(string email);
    Task<CompanyDetailsForProfileViewModel> GetCompanyDetailsByEmailForProfile(string email);
}
