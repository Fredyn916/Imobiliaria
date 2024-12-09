using Entidades.Imoveis.Pai;
    
namespace Entidades.Imoveis.Filho;

public class Apartamento : Imovel
{
	public override int Quartos { get; set; }
	public override int Suites { get; set; }
	public override int Banheiros { get; set; }
	public override int Vagas { get; set; }
	public override int Andar { get; set; }

	public Apartamento()
	{
		base.Tipo = "Apartamento";
	}
}
