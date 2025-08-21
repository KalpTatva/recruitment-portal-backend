using Microsoft.EntityFrameworkCore.Storage;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly RecruitmentPortalContext _context;
    public IUserRepository userRepository { get; set; }
    public IProfileRepository profileRepository { get; set; }
    public ICompanyRepository companyRepository { get; set; }
    public ICountryRepository countryRepository { get; set; }
    public IStateRepository stateRepository { get; set; }
    public UnitOfWork(RecruitmentPortalContext context)
    {
        _context = context;
        userRepository = new UserRepository(_context);
        profileRepository = new ProfileRepository(_context);
        companyRepository = new CompanyRepository(_context);
        countryRepository = new CountryRepository(_context);
        stateRepository = new StateRepository(_context);
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
