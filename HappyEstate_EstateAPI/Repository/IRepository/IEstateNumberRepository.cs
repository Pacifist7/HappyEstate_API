using HappyEstate_EstateAPI.Models;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository.IRepository
{
    public interface IEstateNumberRepository : IRepository<EstateNumber>
    {
        Task<EstateNumber> UpdateAsync(EstateNumber entity);
    }
}
