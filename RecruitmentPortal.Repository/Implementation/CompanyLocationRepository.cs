using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Repository.ViewModels;

namespace RecruitmentPortal.Repository.Implementation;

public class CompanyLocationRepository : GenericRepository<Models.CompanyLocation>, ICompanyLocationRepository
{
    private readonly RecruitmentPortalContext _context;

    public CompanyLocationRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }


    public async Task<List<CompanyLocationWithNameForProfileViewModel>> GetCompanyLocations(int userId)
    {
        try
        {
            return await (from c in _context.Companies
                          join cl in _context.CompanyLocations
                          on c.CompanyId equals cl.CompanyId
                          where c.UserId == userId
                          select new CompanyLocationWithNameForProfileViewModel
                          {
                              CompanyLocationId = cl.CompanyLocationId,
                              CountryId = cl.CountryId,
                              StateId = cl.StateId,
                              CityId = cl.CityId,
                              Country = cl.Country.CountryName,
                              State = cl.State.StateName,
                              City = cl.City.CityName,
                              Address = cl.Address,
                          }
                          ).ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
