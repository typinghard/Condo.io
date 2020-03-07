using CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection;
using Microsoft.Extensions.Configuration;

namespace CondominioService.BuildingBlocks.Data.MongoDB.Connection
{
    public class Config : IConfig
    {
        public IConfiguration Configuration { get; }

        public const string DATABASE = "condominio-service";

        public Config(IConfiguration configuration)
        {
            Configuration = configuration;
            MongoConnectionString = Configuration["MongoDB:ConnectionString"];
            MongoDatabase = Configuration["MongoDB:Database"];
        }

        public Config(string connectionString, string database)
        {
            MongoConnectionString = connectionString;
            MongoDatabase = database;
        }
        public string MongoConnectionString { get; private set; }
        public string MongoDatabase { get; private set; }
    }
}
