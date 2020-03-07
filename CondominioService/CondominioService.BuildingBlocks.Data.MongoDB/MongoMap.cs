﻿using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.BuildingBlocks.Data.MongoDB
{
    public abstract class MongoMap<TEntity> where TEntity : class
    {
        protected bool IsClassMapRegistered()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(TEntity)))
                return true;
            return false;
        }
    }
}
