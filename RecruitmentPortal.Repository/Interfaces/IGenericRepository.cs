using System.Linq.Expressions;

namespace RecruitmentPortal.Repository.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> FindAllAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBySelector, bool ascending = true);
    Task<List<T>> FindAllAsync<TKey>(
        Expression<Func<T, bool>> predicate, 
        Expression<Func<T, TKey>> orderBySelector, 
        bool ascending = true,
        int currentPage = 0,
        int pageSize = 0);
}
