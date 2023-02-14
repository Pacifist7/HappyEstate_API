using AutoMapper;
using HappyEstate_EstateAPI.Models;
using HappyEstate_Web.Models;
using HappyEstate_Web.Models.Dto;
using HappyEstate_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HappyEstate_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;
        public HomeController(IEstateService estateService, IMapper mapper)
        {
            _estateService = estateService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<EstateDTO> list = new();
            var response = await _estateService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EstateDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}