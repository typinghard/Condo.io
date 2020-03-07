using CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection;
using CondominioService.Core.DomainObjects;
using CondominioService.DenunciaContext.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Data
{
    public class DenunciaContext : IDisposable
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IClientSessionHandle _session;
        public DenunciaContext(IConfiguration configuration)
        {
            _mongoClient = new MongoClient(configuration["DataBase:ConnectionString"]);
            _session = _mongoClient.StartSession();
            _database = _mongoClient.GetDatabase(configuration["DataBase:Name"]);
            Map();
        }

        protected void Map()
        {
            new DenunciaMap();
        }
        public int SalvarAlteracoes()
        {
            try
            {
                _session.CommitTransaction();
                return 1;
            }
            catch
            {
                _session.AbortTransaction();
                return 0;
            }
        }

        public IClientSessionHandle Session { get { return _session; } }

        public IMongoCollection<T> Set<T>() where T : Entity
        {
            return _database.GetCollection<T>(typeof(T).Name.ToLower(),
                new MongoCollectionSettings() {
                    GuidRepresentation = MongoDB.Bson.GuidRepresentation.CSharpLegacy
                });
            
        }

        internal IMongoCollection<Denuncia> Denuncias { get { return _database.GetCollection<Denuncia>(typeof(Denuncia).Name.ToLower()); } }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
