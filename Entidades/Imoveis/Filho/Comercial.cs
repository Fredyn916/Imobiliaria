using Entidades.Imoveis.Pai;

namespace Entidades.Imoveis.Filho;

public class Comercial : Imovel
{
    public override int Banheiros { get; set; }
    public override int Vagas { get; set; }
    public override string TipoNegocio { get; set; }

    public Comercial()
	{
		base.Tipo = "Comercial";
	}
}
