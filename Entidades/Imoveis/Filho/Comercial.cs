using Entidades.Imoveis.Pai;

namespace Entidades.Imoveis.Filho;

public class Comercial : Imovel
{
<<<<<<< HEAD
	public Comercial()
=======
    public int Banheiros { get; set; }
    public int Vagas { get; set; }
    public string TipoNegocio { get; set; }

    public Comercial()
>>>>>>> main
	{
		base.Tipo = "Comercial";
	}
}
