using HappyEstate_EstateAPI.Data;
using HappyEstate_EstateAPI.Models;
using HappyEstate_EstateAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository
{
    public class EstateRepository : Repository<Estate>, IEstateRepository
    {
        private readonly ApplicationDbContext _db;
        public EstateRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<Estate> UpdateAsync(Estate entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Estates.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
