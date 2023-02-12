using AutoMapper;
using HappyEstate_EstateAPI.Models;
using HappyEstate_Web.Models.Dto;
using HappyEstate_Web.Services;
using HappyEstate_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HappyEstate_Web.Controllers
{
    public class EstateNumberController : Controller
    {
        private readonly IEstateNumberService _estateNumberService;
        private readonly IMapper _mapper;
        public EstateNumberController(IEstateNumberService estateNumberService, IMapper mapper) 
        { 
            _estateNumberService= estateNumberService;
            _mapper= mapper;
        }
        public async Task<IActionResult> IndexEstateNumber()
        {
            List<EstateNumberDTO> list = new();

            var response = await _estateNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EstateNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
