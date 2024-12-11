using Entidades.DTOs.Usuarios;
using Entidades.Usuarios;

namespace Entidades.Interfaces.Usuarios;

public interface IUsuarioRepository
{
    ReturnUsuarioIdDTO Adicionar(Usuario usuario);
    Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin);
    List<Usuario> Listar();
    Usuario BuscarUsuarioPorId(int id);
    void Editar(Usuario usuarioEdit);
    void EditarUsername(int id, string username);
    void EditarSenha(int id, string senha);
    void Remover(int id);
}