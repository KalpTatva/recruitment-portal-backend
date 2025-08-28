using Microsoft.AspNetCore.Http;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Service.Interfaces;

public interface ICompanyService
{
    Task<ResponseViewModel<CompanyDetailsViewModel>> GetCompanyDetailsByEmail(string Email);
    Task<ResponseViewModel<string>> EditCompanyDetails(CompanyDetailsViewModel companyDetails);
    Task<ResponseViewModel<CompanyDetailsForProfileViewModel>> GetCompanyDetailsByEmailForProfile(string Email);
    Task<ResponseViewModel<string>> UploadCompanyLogo(IFormFile file, string email);
}
