using HappyEstate_EstateAPI.Models;
using System.Linq.Expressions;

namespace HappyEstate_EstateAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsnyc(Expression<Func<T, bool>>? filter = null, string? includePreperties = null);
        Task<T> GetAsnyc(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task CreateAsnyc(T entity);
        Task RemoveAsnyc(T entity);
        Task SaveAsnyc();
    }
}
