﻿namespace Core.DataBase.Scripts;

public static class DataBaseScripts
{
    public static string CreateTables()
    {
        string CreateCommand = @"
            CREATE TABLE IF NOT EXISTS Usuarios(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Idade INTEGER NOT NULL,
                Genero TEXT NOT NULL,
                CEP TEXT NOT NULL,
                Rua TEXT NOT NULL,
                Numero INTEGER NOT NULL,
                Bairro TEXT NOT NULL,
                Cidade TEXT NOT NULL,
                UnidadeFederativa TEXT NOT NULL,
                Endereco TEXT NOT NULL,
                Identificacao TEXT NOT NULL,
                Username TEXT NOT NULL,
                Password TEXT NOT NULL,
                Tipo TEXT NOT NULL
            );";

        return CreateCommand;
    }
}
