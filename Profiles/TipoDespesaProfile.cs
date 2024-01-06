using AutoMapper;
using GerenciaAutoNetAPI.Data.Dtos.TipoDespesa;
using GerenciaAutoNetAPI.Models;

namespace GerenciaAutoNetAPI.Profiles
{
    public class TipoDespesaProfile : Profile
    {
        public TipoDespesaProfile()
        {
            CreateMap<CreateTipoDespesaDto, TipoDespesa>();
            CreateMap<TipoDespesa, ReadTipoDespesaDto>();
            CreateMap<TipoDespesa, UpdateTipoDespesaDto>();
            CreateMap<UpdateTipoDespesaDto, TipoDespesa>();
        }
    }
}
