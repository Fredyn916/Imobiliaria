using Core.DataBase.SQLite.Scripts;
using Dapper;
using System.Data.SQLite;

namespace Core.DataBase.SQLite;

public class InicializadorDb
{
    public static void Inicializar()
    {
        using var connection = new SQLiteConnection("Data Source=Imobiliaria.db");

        connection.Execute(DataBaseScripts.CreateTables());

        int usuarioCount = connection.QueryFirst<int>(UsuarioScripts.CountSelectAllUsuarios());

        if (usuarioCount == 0)
        {
            connection.Execute(UsuarioScripts.InsertUsuarioAdmin());
        }
    }
}