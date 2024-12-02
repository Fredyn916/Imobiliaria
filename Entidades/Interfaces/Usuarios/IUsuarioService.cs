using Entidades.DTOs.Usuarios;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Http;

namespace Entidades.Interfaces.Usuarios;

public interface IUsuarioService
{
    Task Adicionar(Usuario usuario, IFormFile file);
    Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin);
    List<Usuario> Listar();
    Usuario BuscarUsuarioPorId(int id);
    void Editar(Usuario usuarioEdit);
    void Remover(int id);
}