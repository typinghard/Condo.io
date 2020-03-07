using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioService.Core.Messages;

namespace CondominioService.Core.Data.EventSourcing
{
    public interface IEventSourcingRepository
    {
        void SalvarEvento<TEvent>(TEvent evento) where TEvent : Event;
        IList<StoredEvent> ObterEventos(Guid aggregateId);
    }
}
