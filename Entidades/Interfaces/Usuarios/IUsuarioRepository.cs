using Entidades.DTOs.Usuarios;
using Entidades.Usuarios;

namespace Entidades.Interfaces.Usuarios;

public interface IUsuarioRepository
{
    void Adicionar(Usuario usuario);
    Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin);
    List<Usuario> Listar();
    Usuario BuscarUsuarioPorId(int id);
    void Editar(Usuario usuarioEdit);
    void Remover(int id);
}