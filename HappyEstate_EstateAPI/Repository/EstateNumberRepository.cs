using HappyEstate_EstateAPI.Data;
using HappyEstate_EstateAPI.Models;
using HappyEstate_EstateAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository
{
    public class EstateNumberRepository : Repository<EstateNumber>, IEstateNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public EstateNumberRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<EstateNumber> UpdateAsync(EstateNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.EstateNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
