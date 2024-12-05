using AutoMapper;
using Entidades.DTOs.Usuarios;
using Entidades.Usuarios;

namespace Entidades.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUsuarioDTO, Usuario>().ReverseMap();
        CreateMap<ReturnUsuarioIdDTO, Usuario>().ReverseMap();
    }
}