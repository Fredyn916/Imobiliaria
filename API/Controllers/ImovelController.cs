﻿using Entidades.DTOs.Imoveis;
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
}