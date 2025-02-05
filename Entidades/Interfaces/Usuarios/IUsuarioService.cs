﻿using Entidades.DTOs.Usuarios;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Http;

namespace Entidades.Interfaces.Usuarios;

public interface IUsuarioService
{
    ReturnUsuarioIdDTO Adicionar(Usuario usuario);
    Task<string> UploadImage(IFormFile imagem, int usuarioId);
    Usuario LogarUsuario(LoginUsuarioDTO usuarioLogin);
    List<Usuario> Listar();
    Usuario BuscarUsuarioPorId(int id);
    void Editar(Usuario usuarioEdit);
    void EditarUsername(int id, string username);
    void EditarSenha(int id, string senha);
    void Remover(int id);
}