using Dapper.Contrib.Extensions;
using Entidades.DTOs.Usuarios;
using Entidades.Interfaces.Usuarios;
using Entidades.Usuarios;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace Core.Repositorios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string _ConnectionString;

    public UsuarioRepository(IConfiguration connection)
    {
        _ConnectionString = connection.GetConnectionString("DefaultConnection");
    }

    public async Task Adicionar(Usuario usuario)
    {
        using var connection = new SQLiteConnection(_ConnectionString);

        await connection.InsertAsync<Usuario>(usuario);
    }

    public Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin)
    {
        List<Usuario> usuarios = Listar();

        foreach (Usuario usuario in usuarios)
        {
            if (usuarioLogin.Username == usuario.Username && usuarioLogin.Password == usuario.Password)
            {
                return usuario;
            }
        }

        return null;
    }

    public List<Usuario> Listar()
    {
        using var connection = new SQLiteConnection(_ConnectionString);

        List<Usuario> usuarios = connection.GetAll<Usuario>().ToList();

        return usuarios;
    }

    public Usuario BuscarUsuarioPorId(int id)
    {
        using var connection = new SQLiteConnection(_ConnectionString);

        Usuario usuario = connection.Get<Usuario>(id);

        return usuario;
    }

    public void Editar(Usuario usuarioEdit)
    {
        using var connection = new SQLiteConnection(_ConnectionString);

        connection.Update<Usuario>(usuarioEdit);
    }

    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(_ConnectionString);

        Usuario usuarioToRemove = BuscarUsuarioPorId(id);

        connection.Delete<Usuario>(usuarioToRemove);
    }
}