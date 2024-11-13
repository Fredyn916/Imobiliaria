using Entidades.Imoveis.Pai;
using Microsoft.AspNetCore.Mvc;

namespace Entidades.Interfaces.Imoveis;

public interface IImovelService
{
    Task Adicionar([FromBody] Imovel imovel);
    Task<List<Imovel>> Listar();
    Task<Imovel> BuscarImovelPorId(string id);
    Task<List<string>> BuscarURLsImagensPorId(string id);
    Task Editar(Imovel imovel);
    Task Remover(string id);
}
