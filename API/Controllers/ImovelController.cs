using AutoMapper;
using Entidades.DTOs.Imoveis;
using Entidades.Imoveis.Filho;
using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")] 
public class ImovelController : ControllerBase
{
    private readonly IImovelService _Service;
    private readonly IMapper _Mapper;

    public ImovelController(IImovelService imovelService, IMapper mapper)
    {
        _Service = imovelService;
        _Mapper = mapper;
    }

    [HttpPost("AdicionarImovel")]
    public async Task<ReturnImovelIdDTO> Adicionar([FromBody] Imovel imovel)
    {
        return await _Service.Adicionar(ReturnTipoImovel(imovel));
    }

    [HttpPut("UploadImage")]
    public async Task<string> UploadImage(IFormFile imagem, string imovelId)
    {
        return await _Service.UploadImage(imagem, imovelId);
    }

    [HttpGet("ListarImoveis")]
    public async Task<List<Imovel>> Listar()
    {
        return await _Service.Listar();
    }

    [HttpGet("ListarImovelPorId")]
    public async Task<Imovel> BuscarImovelPorId(string id)
    {
        return await _Service.BuscarImovelPorId(id);
    }

    [HttpGet("ListarImoveisPorTipo")]
    public async Task<List<Imovel>> BuscarImoveisPorTipo(string tipo)
    {
        return await _Service.BuscarImoveisPorTipo(tipo);
    }

    [HttpGet("ListarURLsImagensPorId")]
    public async Task<List<string>> BuscarURLsImagensPorId(string id)
    {
        return await _Service.BuscarURLsImagensPorId(id);
    }

    [HttpPut("EditarImovel")]
    public async Task Editar(Imovel imovelEdit)
    {
        _Service.Editar(imovelEdit);
    }

    [HttpDelete("RemoverImovel")]
    public async Task Remover(string id)
    {
        _Service.Remover(id);
    }

    [HttpPost("InicializarImoveis")]
    public async Task InicializarImoveisPreDefinidos()
    {
        _Service.InicializarImoveisPreDefinidos();
    }

    [HttpPost("PrecificarImovel")]
    public async Task<ReturnPrecificadorImovelDTO> PrecificarImovel(PrecificadorImovelDTO imovel)
    {
        return await _Service.PrecificarImovel(imovel);
    }

    private Imovel ReturnTipoImovel(Imovel imovel)
    {
        switch (imovel.Tipo)
        {
            case "Apartamento":
                Apartamento apartamento = _Mapper.Map<Apartamento>(imovel);
                return apartamento;
            case "Casa":
                Casa casa = _Mapper.Map<Casa>(imovel);
                return casa;
            case "Comercial":
                Comercial comercial = _Mapper.Map<Comercial>(imovel);
                return comercial;
            case "Lote":
                Lote lote = _Mapper.Map<Lote>(imovel);
                return lote;
            case "Rural":
                Rural rural = _Mapper.Map<Rural>(imovel);
                return rural;
            case "Terreno":
                Terreno terreno = _Mapper.Map<Terreno>(imovel);
                return terreno;
            default:
                return imovel;
        }
    }
}