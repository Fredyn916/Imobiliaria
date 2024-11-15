using Entidades.Imoveis.Pai;

namespace Entidades.Imoveis.Filho;

public class Comercial : Imovel
{
    public int Banheiros { get; set; }
    public int Vagas { get; set; }

    public Comercial()
	{
		base.Tipo = "Comercial";
	}
}
