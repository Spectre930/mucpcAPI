using Microsoft.EntityFrameworkCore;
using mucpc.Dmain.Repositories;
using MUCPC.Infrastructure.Persistence;
using System;
using System.Linq.Expressions;


namespace mucpc.Infrastructure.Repositories;

internal class Repository<T> : IRepository<T> where T : class
{
    private readonly mucpcDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(mucpcDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }
    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(string[] includes, int pageNumber)
    {
        IQueryable<T> query = dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        var list = await query.ToListAsync();

        if (pageNumber != 0)
        {
            list = list.Skip((pageNumber - 1) * 15)
                   .Take(15)
                   .ToList();
        }
        return list;
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string[] includes = null)
    {
        IQueryable<T> query = dbSet;
        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(filter);
    }




    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }
}
