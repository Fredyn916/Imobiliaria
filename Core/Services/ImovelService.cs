using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Core.Services;

public class ImovelService : IImovelService
{
    private readonly IImovelRepository _Repository;

    public ImovelService(IImovelRepository imovelRepository)
	{
        _Repository = imovelRepository;
	}

    public async Task Adicionar([FromBody] Imovel imovel)
    {
        _Repository.Adicionar(imovel);
    }

    public async Task<List<Imovel>> Listar()
    {
        return await _Repository.Listar();
    }

    public async Task<Imovel> BuscarImovelPorId(string id)
    {
        return await _Repository.BuscarImovelPorId(id);
    }

    public async Task<List<string>> BuscarURLsImagensPorId(string id)
    {
        return await _Repository.BuscarURLsImagensPorId(id);
    }

    public async Task Editar(Imovel imovelEdit)
    {
        _Repository.Editar(imovelEdit);
    }

    public async Task Remover(string id)
    {
        _Repository.Remover(id);
    }
}