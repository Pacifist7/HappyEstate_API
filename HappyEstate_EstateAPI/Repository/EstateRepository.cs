using HappyEstate_EstateAPI.Data;
using HappyEstate_EstateAPI.Models;
using HappyEstate_EstateAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository
{
    public class EstateRepository : IEstateRepository
    {
        private readonly ApplicationDbContext _db;
        public async Task CreateAsnyc(Estate entity)
        {
            await _db.Estates.AddAsync(entity);
            await SaveAsnyc();
        }

        public async Task<Estate> GetAsnyc(Expression<Func<Estate, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Estate> query = _db.Estates;
            
            if(!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Estate>> GetAllAsnyc(Expression<Func<Estate, bool>> filter = null)
        {
            IQueryable<Estate> query = _db.Estates;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsnyc(Estate entity)
        {
            _db.Estates.Remove(entity);
            await SaveAsnyc();
        }

        public async Task SaveAsnyc()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estate entity)
        {
            _db.Estates.Update(entity);
            await SaveAsnyc();
        }
    }
}
