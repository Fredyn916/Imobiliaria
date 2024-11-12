using Entidades.Imoveis.Pai;

namespace Entidades.Interfaces.Imoveis;

public interface IImovelRepository
{
    void Adicionar(Imovel imovel);
    List<Imovel> Listar();
    Imovel BuscarImovelPorId(string id);
    void Editar(Imovel imovel);
    void Remover(string id);
}