namespace Entidades.DTOs.Imoveis;

public class PrecificadorImovelDTO
{
    public string Endereco { get; set; }
    public string VendaOuAluguel { get; set; }
    public bool Novo { get; set; }
    public string TipoImovel { get; set; }
    public int Quartos { get; set; }
    public int Banheiros { get; set; }
    public int Vagas { get; set; }
    public double AreaM2 { get; set; }
    public List<string> AreasComuns { get; set; } = new List<string>(); 
    public string Email { get; set; }
    public string Telefone { get; set; }
}