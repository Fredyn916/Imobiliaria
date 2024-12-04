using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Entidades.DTOs.Usuarios;
using Entidades.Interfaces.Usuarios;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

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

    public int Adicionar(Usuario usuario)
    {
        return _Repository.Adicionar(usuario);
    }

    public async Task<string> UploadImage(IFormFile imagem, int usuarioId)
    {
        Usuario usuario = BuscarUsuarioPorId(usuarioId);

        string fileName = imagem.FileName;

        byte[] imagemBytes;
        using (var memoryStream = new MemoryStream())
        {
            await imagem.CopyToAsync(memoryStream);
            imagemBytes = memoryStream.ToArray();
        }

        using (var memoryStream = new MemoryStream(imagemBytes))
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, memoryStream)
            };
            var uploadResult = await _Cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return "Erro ao carregar a imagem.";
            }

            usuario.FotoDePerfilURL = uploadResult.SecureUrl.ToString();

            Editar(usuario);

            return uploadResult.SecureUrl.ToString();
        }
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