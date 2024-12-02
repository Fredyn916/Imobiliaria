namespace Entidades.DTOs.Usuarios;

public class CreateUsuarioDTO
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Genero { get; set; }
    public string CEP { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string UnidadeFederativa { get; set; }
    public string Identificacao { get; set; } // CPF, CNPJ, CNH, CTPS, RG, etc...
    public string Username { get; set; }
    public string Password { get; set; }
}
