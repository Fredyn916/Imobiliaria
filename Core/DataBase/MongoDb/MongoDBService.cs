using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Core.DataBase.MongoDb;

public class MongoDBService
{
	private readonly IConfiguration _Configuration;
	private readonly IMongoDatabase? _DataBase; 

	public MongoDBService(IConfiguration connection)
	{
		_Configuration = connection;

		var connectionString = _Configuration.GetConnectionString("MongoDbConnection");
		var mongoUrl = MongoUrl.Create(connectionString);
		var mongoCliente = new MongoClient(mongoUrl);
		_DataBase = mongoCliente.GetDatabase(mongoUrl.DatabaseName);
	}

	public IMongoDatabase? DataBase => _DataBase;
}