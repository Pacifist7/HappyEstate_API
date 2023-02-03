using AutoMapper;
using HappyEstate_EstateAPI.Models;
using HappyEstate_EstateAPI.Models.Dto;
using Microsoft.Identity.Client;

namespace HappyEstate_EstateAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Estate, EstateDTO>();
            CreateMap<EstateDTO, Estate>();

            CreateMap<Estate, EstateCreateDTO>().ReverseMap();
            CreateMap<Estate, EstateUpdateDTO>().ReverseMap();


            CreateMap<EstateNumber, EstateNumberDTO>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberCreateDTO>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberUpdateDTO>().ReverseMap();
        }
    }
}
