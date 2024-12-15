using AutoMapper;
using ProviderMS.Commons.Dtos.Request.Grua;
using ProviderMS.Domain.Entities;

namespace ProviderMS.Application.Mapper
{
    public class EntryGruaMapper : Profile
    {

        public EntryGruaMapper()
        {
            CreateMap<CreateGruaDto, Grua>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Estatus, opt => opt.MapFrom(src => "Activo")); // Asigna "Activo" al status
        }
    }
}
