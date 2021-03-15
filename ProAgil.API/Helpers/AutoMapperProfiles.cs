using System.Linq;
using AutoMapper;
using ProAgil.API.Dtos;
using ProAgil.Domain;

namespace ProAgil.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>().ForMember(dest => dest.Palestrantes, opt =>
            {
                opt.MapFrom(src => src.PalestrantesEvento.Select(x => x.Palestrante).ToList());
            }).ReverseMap();

            //CreateMap<EventoDto, Evento>();


            CreateMap<Palestrante, PalestranteDto>().ForMember(dest => dest.Evento, opt =>
            {
                opt.MapFrom(src => src.PalestrantesEvento.Select(x => x.Evento).ToList());
            }).ReverseMap();
            
            CreateMap<Lote, LoteDto>().ReverseMap();
            //CreateMap<LoteDto,Lote>();

            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            //CreateMap<RedeSocialDto,RedeSocial>(); 
        }
    }
}