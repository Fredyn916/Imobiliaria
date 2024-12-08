using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Entidades.DTOs.Usuarios;
using Entidades.Interfaces.Usuarios;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Http;

namespace Core.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _Repository;
    private readonly Cloudinary _Cloudinary;

    public UsuarioService(IUsuarioRepository usuarioRepository, Cloudinary cloudinary)
    {
        _Repository = usuarioRepository;
        _Cloudinary = cloudinary;
    }

    public async Task Adicionar(Usuario usuario, byte[] imageData, string fileName)
    {
        using var stream = new MemoryStream(imageData); // Fluxo de Dados da imagem em byte array para Stream

        IFormFile file = new FormFile(stream, 0, imageData.Length, "file", fileName); // Preenchimento de uma instância de IFormFile

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, file.OpenReadStream())
        };
        var uploadResult = await _Cloudinary.UploadAsync(uploadParams); // Hopedagem da imagem na nuvem da ferramenta Cloudinary

        usuario.FotoDePerfilURL = uploadResult.SecureUrl.ToString(); // Preenche a propriedade do Usuário com a URL da imagem

        await _Repository.Adicionar(usuario);
    }

    public Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin)
    {
        return _Repository.LogarUsuario(usuarioLogin);
    }

    public List<Usuario> Listar()
    {
        return _Repository.Listar();
    }

    public Usuario BuscarUsuarioPorId(int id)
    {
        return _Repository.BuscarUsuarioPorId(id);
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