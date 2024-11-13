using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")] 
public class ImovelController : ControllerBase
{
    private readonly IImovelService _Service;

    public ImovelController(IImovelService imovelService)
    {
        _Service = imovelService;
    }

    [HttpPost("AdicionarImovel")]
    public async Task Adicionar([FromBody] Imovel imovel)
    {
        _Service.Adicionar(imovel);
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
}