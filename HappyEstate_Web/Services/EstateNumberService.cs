using HappyEstate_Utility;
using HappyEstate_Web.Models;
using HappyEstate_Web.Models.Dto;
using HappyEstate_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HappyEstate_Web.Services
{
    public class EstateNumberService : BaseService, IEstateNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string estateUrl;
        public EstateNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory= clientFactory;
            estateUrl = configuration.GetValue<string>("ServiceUrls:EstateAPI");
        }

        public Task<T> CreateAsync<T>(EstateNumberCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = estateUrl + "/api/EstateNumberAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = estateUrl + "/api/EstateNumberAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateNumberAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateNumberAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(EstateNumberUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = estateUrl + "/api/EstateNumberAPI/" + dto.EstateNo
            });
        }
    }
}

