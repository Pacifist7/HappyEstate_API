using AutoMapper;
using HappyEstate_EstateAPI.Models;
using HappyEstate_Web.Models.Dto;
using HappyEstate_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HappyEstate_Web.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;
        public EstateController(IEstateService estateService, IMapper mapper)
        {
            _estateService = estateService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexEstate()
        {
            List<EstateDTO> list = new();
            var response = await _estateService.GetAllAsync<APIResponse>();
            if(response == null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EstateDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
