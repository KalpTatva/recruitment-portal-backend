using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    private readonly RecruitmentPortalContext _context;

    public CountryRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }
}
