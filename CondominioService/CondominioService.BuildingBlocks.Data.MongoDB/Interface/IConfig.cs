using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection
{
    public interface IConfig
    {
        string MongoConnectionString { get; }
        string MongoDatabase { get; }
    }
}
