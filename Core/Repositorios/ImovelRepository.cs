using Core.DataBase.MongoDb;
using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Core.Repositorios;

public class ImovelRepository : IImovelRepository
{
    private readonly IMongoCollection<Imovel> _Imoveis;

    public ImovelRepository(MongoDBService mongoDbService)
    {
        _Imoveis = mongoDbService.DataBase?.GetCollection<Imovel>("Imoveis");
    }

    public void Adicionar([FromBody] Imovel imovel)
    {
        _Imoveis.InsertOne(imovel);
    }

    public List<Imovel> Listar()
    {
        return _Imoveis.Find(imovel => true).ToList();
    }

    public Imovel BuscarImovelPorId(string id)
    {
        return _Imoveis.Find<Imovel>(imovel => imovel.Id == id).FirstOrDefault();
    }

    public void Editar(Imovel imovel)
    {
        _Imoveis.ReplaceOne(imovel => imovel.Id == imovel.Id, imovel);
    }

    public void Remover(string id)
    {
        _Imoveis.DeleteOne(imovel => imovel.Id == id);
    }
}