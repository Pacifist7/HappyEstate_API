using HappyEstate_Web.Models.Dto;

namespace HappyEstate_Web.Services.IServices
{
    public interface IEstateService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(EstateCreateDTO dto);
        Task<T> UpdateAsync<T>(EstateUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);

    }
}
