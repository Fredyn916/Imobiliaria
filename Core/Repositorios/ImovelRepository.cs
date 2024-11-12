using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Core.Repositorios;

public class ImovelRepository : IImovelRepository
{
    private readonly IMongoCollection<Imovel> _Imoveis;

    public ImovelRepository(IMongoDatabase database)
    {
        try
        {
            _Imoveis = database.GetCollection<Imovel>("Imoveis");
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Adicionar([FromBody] Imovel imovel)
    {
        try
        {
            await _Imoveis.InsertOneAsync(imovel);
        }

        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Imovel>> Listar()
    {
        try
        {
            return await _Imoveis.Find(imovel => true).ToListAsync();
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Imovel> BuscarImovelPorId(string id)
    {
        try
        {
            return await _Imoveis.Find<Imovel>(imovel => imovel.Id == id).FirstOrDefaultAsync();
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Editar(Imovel imovel)
    {
        try
        {
            await _Imoveis.ReplaceOneAsync(imovel => imovel.Id == imovel.Id, imovel);
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Remover(string id)
    {
        try
        {
            await _Imoveis.DeleteOneAsync(imovel => imovel.Id == id);
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}