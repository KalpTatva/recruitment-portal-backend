using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;

namespace RecruitmentPortal.Repository.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly RecruitmentPortalContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(RecruitmentPortalContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new Exception($"Entity with id {id} not found.");
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error adding entity: {e.Message}");
        }
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error updating entity: {e.Message}");
        }
    }

    public async Task DeleteAsync(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting entity: {e.Message}");
        }
    }


    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting entities: {e.Message}");
        }
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting entities: {e.Message}");
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting entities: {e.Message}");
        }
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _dbSet.CountAsync(predicate);
        }
        catch (Exception e)
        {
            throw new Exception($"Error counting entities: {e.Message}");
        }
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        catch (Exception e)
        {
            throw new Exception($"Error finding entity: {e.Message}");
        }
    }

    public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error finding entities: {e.Message}");
        }
    }

    public async Task<List<T>> FindAllAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBySelector, bool ascending = true)
    {
        try
        {
            var query = _dbSet.Where(predicate);
            query = ascending ? query.OrderBy(orderBySelector) : query.OrderByDescending(orderBySelector);
            return await query.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error finding and ordering entities: {e.Message}");
        }
    }

    public async Task<List<T>> FindAllAsync<TKey>(
        Expression<Func<T, bool>> predicate, 
        Expression<Func<T, TKey>> orderBySelector, 
        bool ascending = true,
        int currentPage = 1,
        int pageSize = 5)
    {
        try
        {
            int skip = (currentPage - 1) * pageSize;
            var query = _dbSet.Where(predicate);
            query = ascending ? query.OrderBy(orderBySelector) : query.OrderByDescending(orderBySelector);
            
            if (currentPage <= 0 || pageSize <= 0)
            {
                query = query.Skip(0).Take(int.MaxValue); 
            }
            else
            {
                query = query.Skip(skip).Take(pageSize);
            }

            return await query.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error finding and ordering entities: {e.Message}");
        }
    }
}
