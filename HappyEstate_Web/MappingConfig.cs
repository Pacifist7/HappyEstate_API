using AutoMapper;
using HappyEstate_Web;
using HappyEstate_Web.Models.Dto;

namespace HappyEstate_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<EstateDTO, EstateCreateDTO>().ReverseMap();
            CreateMap<EstateDTO, EstateUpdateDTO>().ReverseMap();
            CreateMap<EstateNumberDTO, EstateNumberDTO>().ReverseMap();
            CreateMap<EstateNumberDTO, EstateNumberCreateDTO>().ReverseMap();
            CreateMap<EstateNumberDTO, EstateNumberUpdateDTO>().ReverseMap();
        }
    }
}
