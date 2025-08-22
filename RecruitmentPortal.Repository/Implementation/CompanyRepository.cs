using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Implementation;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    private readonly RecruitmentPortalContext _context;
    public CompanyRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<CompanyDetailsViewModel> GetCompanyDetailsByEmail(string email)
    {
        try
        {
            CompanyDetailsViewModel company = new();
            User? user = await _context.Users
                .Where(u => u.Email == email.Trim().ToLower())
                .FirstOrDefaultAsync();
            if(user == null)
            {
                throw new Exception("User not found with the provided email.");
            }

            company.UserId = user.UserId;
            company.UserName = user.UserName;
            company.Email = user.Email;
            
            Company? companyDetails = await _context.Companies
                .Where(c => c.UserId == user.UserId)
                .FirstOrDefaultAsync();
            if (companyDetails?.CompanyId == 0 || companyDetails?.CompanyId == null)
            {
                throw new Exception("No company details found for the provided user.");
            }

            company.CompanyName = companyDetails?.CompanyName ?? "";
            company.CompanyDescription = companyDetails?.Description ?? "";
            company.CompanyType = companyDetails?.CompanyType ?? "";
            company.CompanyLocation = companyDetails?.Location ?? "";
            company.CompanyWebsite = companyDetails?.CompanyWebsite ?? "";
            company.CompanyId = companyDetails?.CompanyId ?? 0;
            company.Phone = companyDetails?.Phone ?? 99999999999;
            company.countryCode = companyDetails?.CountryCode ?? "";

            CompanyStatus? companyStatus = await _context.CompanyStatuses
                .Where(cs => cs.CompanyId == company.CompanyId)
                .FirstOrDefaultAsync();

            company.CompanyFoundedYear = companyStatus?.CompanyFoundedYear ?? 0;
            company.IndustryType = companyStatus?.IndustryType ?? "";
            company.NumberOfFounders = companyStatus?.NumberOfFounders ?? 0;
            company.TotalEmployees = companyStatus?.TotalEmployees ?? 0;
            company.TotalMaleEmployees = companyStatus?.TotalMaleEmployees ?? 0;
            company.TotalFemaleEmployees = companyStatus?.TotalFemaleEmployees ?? 0;
            company.TotalOthersEmployees = companyStatus?.TotalOtherEmployees ?? 0;
            company.TotalRevenue = companyStatus?.TotalRevenue ?? 0;

            CompanySocialMedium? companySocialMedia = await _context.CompanySocialMedia
                .Where(csm => csm.CompanyId == company.CompanyId)
                .FirstOrDefaultAsync();
            
            company.LinkedIn = companySocialMedia?.LinkedIn ?? "";
            company.Twitter = companySocialMedia?.Twitter ?? "";
            company.Facebook = companySocialMedia?.FaceBook ?? "";
            company.Medium = companySocialMedia?.Medium ?? "";

            List<ViewModels.CompanyLocation> companyLocations = await _context.CompanyLocations
                .Where(cl => cl.CompanyId == company.CompanyId)
                .Select(cl => new ViewModels.CompanyLocation
                {
                    CountryId = cl.CountryId,
                    StateId = cl.StateId,
                    Address = cl.Address
                })
                .ToListAsync();
            
            company.CompanyLocations = companyLocations;
            if (company.CompanyLocations == null)
            {
                company.CompanyLocations = new List<ViewModels.CompanyLocation>();
            }

            return company;
        }
        catch (Exception e)
        {
            throw new Exception($"Error retrieving company details: {e.Message}");
        }
    }
}
