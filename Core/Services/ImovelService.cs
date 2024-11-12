using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;

namespace Core.Services;

public class ImovelService : IImovelService
{
    private readonly IImovelRepository _Repository;

    public ImovelService(IImovelRepository imovelRepository)
	{
        _Repository = imovelRepository;
	}

    public void Adicionar(Imovel imovel)
    {
        _Repository.Adicionar(imovel);
    }

    public List<Imovel> Listar()
    {
        return _Repository.Listar();
    }

    public Imovel BuscarImovelPorId(string id)
    {
        return _Repository.BuscarImovelPorId(id);
    }

    public void Editar(Imovel imovel)
    {
        _Repository.Editar(imovel);
    }

    public void Remover(string id)
    {
        _Repository.Remover(id);
    }
}