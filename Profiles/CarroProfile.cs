using AutoMapper;
using GerenciaAutoNetAPI.Data.Dtos.Carro;
using GerenciaAutoNetAPI.Models;

namespace GerenciaAutoNetAPI.Profiles
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<CreateCarroDto, Carro>();
            CreateMap<UpdateCarroDto, Carro>();
            CreateMap<Carro, ReadCarroDto>();
        }
    }
}
