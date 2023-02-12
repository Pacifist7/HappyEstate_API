using HappyEstate_Web.Models.Dto;

namespace HappyEstate_Web.Services.IServices
{
    public interface IEstateNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(EstateNumberCreateDTO dto);
        Task<T> UpdateAsync<T>(EstateNumberUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);

    }
}
