using AutoMapper;
using ProviderMS.Commons.Dtos.Request;
using ProviderMS.Domain.Entities;




namespace UsersMS.Application.Mapper
{
    public class EntryProveedorMapper : Profile
    {
        public EntryProveedorMapper()
        {
            // Mapeo para Proveedor
            CreateMap<CreateProveedorDto, Proveedor>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Estatus, opt => opt.MapFrom(src => "Activo")); // Asigna "Activo" al status
                                                                                       
            CreateMap<ModifyProveedorDto, Proveedor>()
                     .ForMember(dest => dest.Estatus, opt => opt.MapFrom(src => "Activo"));
        }
    }
}
