using HappyEstate_EstateAPI.Models;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository.IRepository
{
    public interface IEstateRepository : IRepository<Estate>
    {
        Task<Estate> UpdateAsync(Estate entity);
    }
}
