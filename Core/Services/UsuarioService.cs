using Entidades.DTOs.Usuarios;
using Entidades.Interfaces.Usuarios;
using Entidades.Usuarios;

namespace Core.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _Repository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _Repository = usuarioRepository;
    }

    public void Adicionar(Usuario usuario)
    {
        _Repository.Adicionar(usuario);
    }

    public List<Usuario> Listar()
    {
        return _Repository.Listar();
    }

    public Usuario BuscarUsuarioPorId(int id)
    {
        return _Repository.BuscarUsuarioPorId(id);
    }

    public Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin)
    {
        return _Repository.LogarUsuario(usuarioLogin);
    }

    public void Editar(Usuario usuarioEdit)
    {
        _Repository.Editar(usuarioEdit);
    }

    public void Remover(int id)
    {
        _Repository.Remover(id);
    }
}