using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using CondominioService.Core.Data.EventSourcing;
using CondominioService.Core.Messages;
using Newtonsoft.Json;
using CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        protected IConnect _connect { get; private set; }
        protected IMongoCollection<StoredEvent> _collection { get; private set; }
        protected string _collectionName { get; private set; }

        public EventSourcingRepository(IConnect connect)
        {
            setCollectionName();
            setConnectAndCollection(connect);
        }
        #region internal
        internal void setCollectionName()
        {
            _collectionName = "storedevent";
        }
        internal void setConnectAndCollection(IConnect connect)
        {
            _connect = connect;
            _collection = _connect.Collection<StoredEvent>(_collectionName);
        }
        #endregion

        public void SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            _collection.InsertOne(FormatarEvento(evento));
        }
        public IList<StoredEvent> ObterEventos(Guid aggregateId)
        {
            IMongoQueryable<StoredEvent> query = _collection.AsQueryable();
            return query.Where(x => x.AggregatedId == aggregateId).OrderBy(x => x.DataOcorrencia).ToList();
        }

        private static StoredEvent FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            return new StoredEvent(
                Guid.NewGuid(),
                evento.AggregateId,
                evento.MessageType,
                evento.Timestamp,
                JsonConvert.SerializeObject(evento));
        }
    }

    internal class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
}
