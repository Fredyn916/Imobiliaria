namespace Core.DataBase.SQLite.Scripts;

public static class UsuarioScripts
{
    public static string CountSelectAllUsuarios()
    {
        string CountCommand = "SELECT COUNT(*) FROM Usuarios;";
        return CountCommand;
    }

    public static string InsertUsuarioAdmin()
    {
        string InsertCommand = @"
            INSERT INTO Usuarios 
                (Nome, Idade, Genero,
                 CEP, Rua, Numero, Bairro, Cidade, 
                 UnidadeFederativa, Endereco, Identificacao,
                 Username, Password, Tipo, FotoDePerfilURL)

            VALUES
                ('Administrador', '', 'Masculino', '34505-730',
                 'Praça Getúlio Vargas', 168, 'Centro', 'Sabará', 'MG',
                 'Praça Getúlio Vargas, 168, Centro, Sabará, MG - 34505-730',
                 '00.000.000/0001-00', 'Admin', 'Admin',
                 'Administrador', 'https://res.cloudinary.com/fredmarques/image/upload/v1734056424/ImagemAdmin_tvdavt.png');";

        return InsertCommand;
    }
}