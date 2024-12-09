using Entidades.DTOs.Imoveis;
using Entidades.Imoveis.Pai;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entidades.Interfaces.Imoveis;

public interface IImovelService
{
    Task<ReturnImovelIdDTO> Adicionar([FromBody] Imovel imovel);
    Task<string> UploadImage(IFormFile imagem, string imovelId);
    Task<List<Imovel>> Listar();
    Task<Imovel> BuscarImovelPorId(string id);
    Task<List<Imovel>> BuscarImoveisPorTipo(string tipo);
    Task<List<string>> BuscarURLsImagensPorId(string id);
    Task Editar(Imovel imovel);
    Task Remover(string id);
    Task InicializarImoveisPreDefinidos();
    Task<ReturnPrecificadorImovelDTO> PrecificarImovel(PrecificadorImovelDTO imovel);
}
