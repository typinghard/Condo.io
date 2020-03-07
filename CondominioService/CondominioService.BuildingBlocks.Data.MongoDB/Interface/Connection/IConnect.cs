using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection
{
    public interface IConnect
    {
        IMongoCollection<T> Collection<T>(string CollectionName);
    }
}
