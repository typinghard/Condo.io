using CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace CondominioService.BuildingBlocks.Data.MongoDB.Connection
{
    public class Connect : IDisposable, IConnect
    {
        protected MongoClient Client { get; private set; }

        protected IMongoDatabase DataBase { get; private set; }
        public IMongoCollection<T> Collection<T>(string CollectionName)
        {
            return DataBase.GetCollection<T>(CollectionName);
        }
        public Connect(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["DataBase:ConnectionString"]);
            DataBase = Client.GetDatabase(configuration["DataBase:Name"]);
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DataBase = null;
                    Client = null;
                }
                disposed = true;
            }
        }
        ~Connect()
        {
            Dispose(false);
        }
        private bool disposed = false;
        #endregion Dispose
    }
}
