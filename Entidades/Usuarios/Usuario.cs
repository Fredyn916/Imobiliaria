namespace Entidades.Usuarios;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Genero { get; set; }
    public string Endereco { get; set; }
    public string Identificacao { get; set; } // CPF, CNPJ, CNH, CTPS, RG, etc...
    public string Username { get; set; }
    public string Password { get; set; }
    public string Tipo { get; set; } // Administrador ou Usuário Convencional
}
