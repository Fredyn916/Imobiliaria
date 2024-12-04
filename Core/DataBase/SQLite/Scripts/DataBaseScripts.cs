namespace Core.DataBase.SQLite.Scripts;

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
                CEP TEXT,
                Rua TEXT,
                Numero INTEGER,
                Bairro TEXT,
                Cidade TEXT,
                UnidadeFederativa TEXT,
                Endereco TEXT,
                Identificacao TEXT NOT NULL,
                Username TEXT NOT NULL,
                Password TEXT NOT NULL,
                Tipo TEXT NOT NULL,
                FotoDePerfilURL TEXT
            );";

        return CreateCommand;
    }
}
