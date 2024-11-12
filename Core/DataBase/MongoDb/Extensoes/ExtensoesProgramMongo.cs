using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Core.DataBase.MongoDb.Extensoes;

public static class ExtensoesProgramMongo
{
    public static IServiceCollection AddConfiguracaoMongo(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MongoDbSettings>(config.GetSection("MongoDbSettings"));

        services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            return new MongoClient(settings.ConnectionString);
        });

        services.AddScoped(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(settings.DatabaseName);
        });

        return services;
    }
}
