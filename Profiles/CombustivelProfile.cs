using AutoMapper;
using GerenciaAutoNetAPI.Data.Dtos.Combustivel;
using GerenciaAutoNetAPI.Models;

namespace GerenciaAutoNetAPI.Profiles
{
    public class CombustivelProfile : Profile
    {
        public CombustivelProfile() 
        {
            CreateMap<CreateCombustivelDto, Combustivel>();
            CreateMap<Combustivel, ReadCombustivelDto>();
        }
    }
}
