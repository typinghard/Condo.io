using CondominioService.BuildingBlocks.Data.MongoDB;
using CondominioService.DenunciaContext.Domain.Models;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Data
{
    public class DenunciaMap : MongoMap<Denuncia>
    {
        public DenunciaMap()
        {
            if (!IsClassMapRegistered())
            {
                BsonClassMap.RegisterClassMap<Denuncia>(cm =>
                {
                    cm.AutoMap();
                });
            }
        }
    }
}
