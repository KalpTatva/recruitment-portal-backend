using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Service.Interfaces;

public interface ICompanyService
{
    Task<ResponseViewModel<CompanyDetailsViewModel>> GetCompanyDetailsByEmail(string Email);
    Task<ResponseViewModel<string>> EditCompanyDetails(CompanyDetailsViewModel companyDetails);
}
