using Entidades.Imoveis.Pai;

namespace Entidades.Imoveis.Filho;

public class Rural : Imovel
{
    public override int Quartos { get; set; }
    public override int Suites { get; set; }
    public override int Banheiros { get; set; }
    public override int Vagas { get; set; }

    public Rural()
	{
		base.Tipo = "Rural";
	}
}
