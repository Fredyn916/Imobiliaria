using Entidades.Imoveis.Pai;
    
namespace Entidades.Imoveis.Filho;

public class Apartamento : Imovel
{
	public int Quartos { get; set; }
	public int Suites { get; set; }
	public int Banheiros { get; set; }
	public int Vagas { get; set; }
	public int Andar { get; set; }

	public Apartamento()
	{
		base.Tipo = "Apartamento";
	}
}
