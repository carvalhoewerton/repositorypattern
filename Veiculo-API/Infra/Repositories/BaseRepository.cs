using Microsoft.EntityFrameworkCore;
using Veiculo_API.Infra.Data;
using Veiculo_API.Infra.Repositories.Interfaces;

namespace Veiculo_API.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T: class
{
    protected ApiDbContext _context;
    internal Microsoft.EntityFrameworkCore.DbSet<T> dbSet;

    public BaseRepository(ApiDbContext context, DbSet<T> dbSet)
    {
        _context = context;
        this.dbSet = dbSet;
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }

    public async Task<bool> Update(T entity)
    {
        dbSet.Update(entity);
        return true;
    }
    

    public async Task<bool> Delete(T entity)
    {
        dbSet.Remove(entity);
        return true;
    }
}