using AutoMapper;
using Entidades.DTOs.Usuarios;
using Entidades.Imoveis.Filho;
using Entidades.Imoveis.Pai;
using Entidades.Usuarios;

namespace Entidades.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUsuarioDTO, Usuario>().ReverseMap();
        CreateMap<ReturnUsuarioIdDTO, Usuario>().ReverseMap();
        CreateMap<Imovel, Apartamento>().ReverseMap();
        CreateMap<Imovel, Casa>().ReverseMap();
        CreateMap<Imovel, Comercial>().ReverseMap();
        CreateMap<Imovel, Lote>().ReverseMap();
        CreateMap<Imovel, Rural>().ReverseMap();
        CreateMap<Imovel, Terreno>().ReverseMap();
    }
}