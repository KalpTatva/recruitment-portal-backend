using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly RecruitmentPortalContext _context;

    public UserRepository(RecruitmentPortalContext context) : base(context)
    {
        _context = context;
    }


}
