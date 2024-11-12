using AutoMapper;
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
    public void Adicionar(Imovel imovel)
    {
        _Service.Adicionar(imovel);
    }

    [HttpGet("ListarImoveis")]
    public List<Imovel> Listar()
    {
        return _Service.Listar();
    }

    [HttpGet("ListarImovelPorId")]
    public Imovel BuscarImovelPorId(string id)
    {
        return _Service.BuscarImovelPorId(id);
    }

    [HttpPut("EditarImovel")]
    public void Editar(Imovel imovelEdit)
    {
        _Service.Editar(imovelEdit);
    }

    [HttpDelete("RemoverImovel")]
    public void Remover(string id)
    {
        _Service.Remover(id);
    }
}