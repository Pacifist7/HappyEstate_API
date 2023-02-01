using HappyEstate_EstateAPI.Models;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository.IRepository
{
    public interface IEstateRepository
    {
        Task<List<Estate>> GetAllAsnyc(Expression<Func<Estate, bool>> filter = null);
        Task<Estate> GetAsnyc(Expression<Func<Estate, bool>> filter = null, bool tracked=true);
        Task CreateAsnyc(Estate entity);
        Task RemoveAsnyc(Estate entity);
        Task UpdateAsync(Estate entity);

        Task SaveAsnyc(); 
    }
}
