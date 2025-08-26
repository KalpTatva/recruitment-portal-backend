using RecruitmentPortal.Repository.Implementation;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;
using RecruitmentPortal.Service.Interfaces;

namespace RecruitmentPortal.Service.Implementation;

public class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    public CompanyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseViewModel<CompanyDetailsViewModel>> GetCompanyDetailsByEmail(string Email)
    {
        try
        {
            ResponseViewModel<CompanyDetailsViewModel> response = new ResponseViewModel<CompanyDetailsViewModel>();
            CompanyDetailsViewModel companyDetails = await _unitOfWork.companyRepository.GetCompanyDetailsByEmail(Email);
            if (companyDetails != null)
            {
                response.Success = true;
                response.data = companyDetails;
                response.Message = "Company details retrieved successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "No company details found for the provided email.";
            }
            return response;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ResponseViewModel<string>> EditCompanyDetails(CompanyDetailsViewModel companyDetails)
    {
        try
        {
            ResponseViewModel<string> response = new ResponseViewModel<string>();

            if (companyDetails == null || companyDetails.CompanyId <= 0 || companyDetails?.CompanyId == null || companyDetails.UserId <= 0)
            {
                response.Success = false;
                response.Message = "Invalid company details provided.";
                return response;
            }

            // update all company details
            Company company = await _unitOfWork.companyRepository.GetByIdAsync(companyDetails.CompanyId);
            if (company == null)
            {
                response.Success = false;
                response.Message = "Company not found.";
                return response;
            }
            company.CompanyName = companyDetails.CompanyName;
            company.Description = companyDetails.CompanyDescription;
            company.CompanyType = companyDetails.CompanyType;
            company.Location = companyDetails.CompanyLocation;
            company.CompanyWebsite = companyDetails.CompanyWebsite;
            company.Phone = companyDetails.Phone;
            company.CountryCode = companyDetails?.countryCode ?? "";

            company.ModifiedAt = DateTime.Now;
            company.ModifiedById = companyDetails?.UserId;

            CompanyStatus? companyStatus = await _unitOfWork.companyStatusRepository.FindAsync(x => x.CompanyId == companyDetails.CompanyId);

            if (companyStatus == null)
            {
                companyStatus = new CompanyStatus
                {
                    CompanyId = companyDetails.CompanyId,
                    CompanyFoundedYear = companyDetails.CompanyFoundedYear,
                    IndustryType = companyDetails.IndustryType,
                    NumberOfFounders = companyDetails.NumberOfFounders,
                    TotalEmployees = companyDetails.TotalEmployees,
                    TotalMaleEmployees = companyDetails.TotalMaleEmployees,
                    TotalFemaleEmployees = companyDetails.TotalFemaleEmployees,
                    TotalOtherEmployees = companyDetails.TotalOthersEmployees,
                    TotalRevenue = companyDetails.TotalRevenue,

                    CreatedById = companyDetails.UserId
                };
                await _unitOfWork.companyStatusRepository.AddAsync(companyStatus);
            }
            else
            {
                companyStatus.CompanyFoundedYear = companyDetails.CompanyFoundedYear;
                companyStatus.IndustryType = companyDetails.IndustryType;
                companyStatus.NumberOfFounders = companyDetails.NumberOfFounders;
                companyStatus.TotalEmployees = companyDetails.TotalEmployees;
                companyStatus.TotalMaleEmployees = companyDetails.TotalMaleEmployees;
                companyStatus.TotalFemaleEmployees = companyDetails.TotalFemaleEmployees;
                companyStatus.TotalOtherEmployees = companyDetails.TotalOthersEmployees;
                companyStatus.TotalRevenue = companyDetails.TotalRevenue;

                companyStatus.ModifiedAt = DateTime.Now;
                companyStatus.ModifiedById = companyDetails.UserId;
                await _unitOfWork.companyStatusRepository.UpdateAsync(companyStatus);
            }


            CompanySocialMedium? companySocialMedia = await _unitOfWork.companySocialMediumRepository.FindAsync(x => x.CompanyId == companyDetails.CompanyId);

            if (companySocialMedia == null)
            {
                companySocialMedia = new CompanySocialMedium
                {
                    CompanyId = companyDetails.CompanyId,
                    LinkedIn = companyDetails.LinkedIn,
                    Twitter = companyDetails.Twitter,
                    FaceBook = companyDetails.Facebook,
                    Medium = companyDetails.Medium,

                    CreatedById = companyDetails.UserId
                };
                await _unitOfWork.companySocialMediumRepository.AddAsync(companySocialMedia);
            }
            else
            {
                companySocialMedia.LinkedIn = companyDetails.LinkedIn;
                companySocialMedia.Twitter = companyDetails.Twitter;
                companySocialMedia.FaceBook = companyDetails.Facebook;
                companySocialMedia.Medium = companyDetails.Medium;

                companySocialMedia.ModifiedAt = DateTime.Now;
                companySocialMedia.ModifiedById = companyDetails.UserId;
                await _unitOfWork.companySocialMediumRepository.UpdateAsync(companySocialMedia);
            }

            // update company locations 
            // need to check if location already exists then update it
            // if not exists then add it
            // if existing deleted then remove it from the db
            // if existing updated then update it in the db
            List<Repository.Models.CompanyLocation> existingLocations = await _unitOfWork.companyLocationRepository.FindAllAsync(x => x.CompanyId == companyDetails.CompanyId && x.IsDeleted == false);
            List<Repository.Models.CompanyLocation> updatedLocations = new List<Repository.Models.CompanyLocation>();
            foreach (Repository.ViewModels.CompanyLocation location in companyDetails.CompanyLocations)
            {
                Repository.Models.CompanyLocation? existingLocation = existingLocations.FirstOrDefault(x => x.CompanyLocationId == location.CompanyLocationId);
                
                if (existingLocation != null)
                {
                    // Update existing location
                    existingLocation.Address = location.Address.Trim().ToLower();
                    existingLocation.ModifiedAt = DateTime.Now;
                    existingLocation.ModifiedById = companyDetails.UserId;
                    updatedLocations.Add(existingLocation);
                }
                else if (location.CompanyLocationId == 0)
                {
                    // Add new location
                    Repository.Models.CompanyLocation newLocation = new Repository.Models.CompanyLocation
                    {
                        CompanyId = companyDetails.CompanyId,
                        CountryId = location.CountryId,
                        StateId = location.StateId,
                        CityId = location.CityId,
                        Address = location.Address.Trim().ToLower(),
                        CreatedById = companyDetails.UserId
                    };
                    updatedLocations.Add(newLocation);
                }
            }
            // Delete locations that are not in the updated list
            foreach (Repository.Models.CompanyLocation existingLocation in existingLocations)
            {
                if (!updatedLocations.Any(
                    x => x.CompanyLocationId == existingLocation.CompanyLocationId
                ))
                {
                    existingLocation.IsDeleted = true;
                    existingLocation.DeletedAt = DateTime.Now;
                    existingLocation.DeletedById = companyDetails.UserId;
                    await _unitOfWork.companyLocationRepository.UpdateAsync(existingLocation);
                }
            }
            // Add or update locations in the database
            foreach (Repository.Models.CompanyLocation updatedLocation in updatedLocations)
            {
                Repository.Models.CompanyLocation? existingLocation = existingLocations.FirstOrDefault(x => x.CompanyLocationId == updatedLocation.CompanyLocationId);
                if (existingLocation != null)
                {
                    // Update existing location
                    await _unitOfWork.companyLocationRepository.UpdateAsync(updatedLocation);
                }
                else
                {
                    // Add new location
                    await _unitOfWork.companyLocationRepository.AddAsync(updatedLocation);
                }
            }

            
            // Save changes to the database
            response.Success = true;
            response.Message = "Company details updated successfully.";
            
            return response;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
