using HappyEstate_EstateAPI.Data;
using HappyEstate_EstateAPI.Models;
using HappyEstate_EstateAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.EstateNumbers.Include(u => u.Estate).ToList();
            this.dbSet = _db.Set<T>();
        }
        public async Task CreateAsnyc(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsnyc();
        }

        public async Task<T> GetAsnyc(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includePreperties = null)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if(includePreperties!= null)
            {
                foreach (var includeProp in includePreperties.Split(new char[] { ',' }, 
                    StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsnyc(Expression<Func<T, bool>>? filter = null, string? includePreperties = null)
        {
            IQueryable<T> query = dbSet;     
            
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includePreperties != null)
            {
                foreach (var includeProp in includePreperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.ToListAsync();
        }

        public async Task RemoveAsnyc(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsnyc();
        }

        public async Task SaveAsnyc()
        {
            await _db.SaveChangesAsync();
        }
    }
}

