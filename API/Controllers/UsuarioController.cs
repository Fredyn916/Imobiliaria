using AutoMapper;
using Entidades.DTOs.Usuarios;
using Entidades.Interfaces.Usuarios;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _Service;
    private readonly IMapper _Mapper;

    public UsuarioController(IMapper mapper, IUsuarioService usuarioService)
    {
        _Service = usuarioService;
        _Mapper = mapper;
    }
    
    [HttpPost("AdicionarUsuario")]
    public async Task Adicionar(IFormFile file, [FromForm] CreateUsuarioDTO usuarioDTO)
    {
        Usuario usuario = _Mapper.Map<Usuario>(usuarioDTO);
        usuario.Endereco = $"{usuarioDTO.Rua}, {usuarioDTO.Numero}, {usuarioDTO.Bairro}, {usuarioDTO.Cidade}, {usuarioDTO.UnidadeFederativa} - {usuarioDTO.CEP}";
        usuario.Tipo = "Usuario";

        await _Service.Adicionar(usuario, file);
    }

    [HttpPost("LogarUsuario")]
    public Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin)
    {
        return _Service.LogarUsuario(usuarioLogin);
    }

    [HttpGet("ListarUsuarios")]
    public List<Usuario> Listar()
    {
        return _Service.Listar();
    }

    [HttpGet("ListarUsuarioPorId")]
    public Usuario BuscarUsuarioPorId(int id)
    {
        return _Service.BuscarUsuarioPorId(id);
    }

    [HttpPut("EditarUsuario")]
    public void Editar(Usuario usuarioEdit)
    {
        usuarioEdit.Tipo = "Usuario";

        _Service.Editar(usuarioEdit);
    }

    [HttpDelete("RemoverUsuario")]
    public void Remover(int id)
    {
        _Service.Remover(id);
    }
}