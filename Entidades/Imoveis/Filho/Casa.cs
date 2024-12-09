using Entidades.Imoveis.Pai;

namespace Entidades.Imoveis.Filho;

public class Casa : Imovel
{
    public override int Quartos { get; set; }
    public override int Suites { get; set; }
    public override int Banheiros { get; set; }
    public override int Vagas { get; set; }

    public Casa()
	{
		base.Tipo = "Casa";
	}
}
