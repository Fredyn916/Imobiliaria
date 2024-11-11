﻿using Entidades.Usuarios;

namespace Entidades.Interfaces.Usuarios;

public interface IUsuarioService
{
    void Adicionar(Usuario usuario);
    List<Usuario> Listar();
    Usuario BuscarUsuarioPorId(int id);
    void Editar(Usuario usuarioEdit);
    void Remover(int id);
}