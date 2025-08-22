using Microsoft.EntityFrameworkCore.Storage;

namespace RecruitmentPortal.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository userRepository { get; set; }
    IProfileRepository profileRepository { get; set; }
    ICountryRepository countryRepository { get; set; }
    IStateRepository stateRepository { get; set; }
    ICompanyRepository companyRepository { get; set; }
    ICompanyLocationRepository companyLocationRepository { get; set; }
    ICompanySocialMediumRepository companySocialMediumRepository { get; set; }
    ICompanyStatusRepository companyStatusRepository { get; set; }
    Task<int> SaveChanges();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
