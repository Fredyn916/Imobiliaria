using Entidades.DTOs.Usuarios;
using Entidades.Usuarios;

namespace Entidades.Interfaces.Usuarios;

public interface IUsuarioRepository
{
    void Adicionar(Usuario usuario);
    List<Usuario> Listar();
    Usuario BuscarUsuarioPorId(int id);
    Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin);
    void Editar(Usuario usuarioEdit);
    void Remover(int id);
}