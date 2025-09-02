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
    public ICompanyLocationRepository companyLocationRepository { get; set; }
    public ICompanySocialMediumRepository companySocialMediumRepository { get; set; }
    public ICompanyStatusRepository companyStatusRepository { get; set; }
    public ICityRepository cityRepository { get; set; }
    public IJobTypeRepository jobTypeRepository { get; set; }
    public IJobRoleRepository jobRoleRepository { get; set; }
    public IDegreeRepository degreeRepository { get; set; }
    public IJobCategoryRepository jobCategoryRepository { get; set; }
    public IJobRepository jobRepository { get; set; }
    public UnitOfWork(RecruitmentPortalContext context)
    {
        _context = context;
        userRepository = new UserRepository(_context);
        profileRepository = new ProfileRepository(_context);
        companyRepository = new CompanyRepository(_context);
        countryRepository = new CountryRepository(_context);
        stateRepository = new StateRepository(_context);
        cityRepository = new CityRepository(_context);
        companyLocationRepository = new CompanyLocationRepository(_context);
        companySocialMediumRepository = new CompanySocialMediumRepository(_context);
        companyStatusRepository = new CompanyStatusRepository(_context);
        jobTypeRepository = new JobTypeRepository(_context);
        jobRoleRepository = new JobRoleRepository(_context);
        degreeRepository = new DegreeRepository(_context);
        jobCategoryRepository = new JobCategoryRepository(_context);
        jobRepository = new JobRepository(_context);
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
