using AutoMapper;
using GerenciaAutoNetAPI.Data.Dtos.Marca;
using GerenciaAutoNetAPI.Models;

namespace GerenciaAutoNetAPI.Profiles
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile()
        {
            CreateMap<CreateMarcaDto, Marca>();
            CreateMap<Marca, ReadMarcaDto>();
        }
    }
}
