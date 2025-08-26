using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class CityRepository : GenericRepository<City>, ICityRepository
{
   private readonly RecruitmentPortalContext _context;

    public CityRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }

}
