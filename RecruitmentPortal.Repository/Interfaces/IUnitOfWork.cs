using Microsoft.EntityFrameworkCore.Storage;

namespace RecruitmentPortal.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository userRepository { get; set; }
    ICompanyRepository companyRepository { get; set; }
    IProfileRepository profileRepository { get; set; }
    Task<int> SaveChanges();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
