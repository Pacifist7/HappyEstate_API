using HappyEstate_EstateAPI.Models;
using HappyEstate_Web.Models;

namespace HappyEstate_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
