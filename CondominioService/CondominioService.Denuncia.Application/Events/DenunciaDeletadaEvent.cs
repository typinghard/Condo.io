using CondominioService.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Application.Events
{
   public class DenunciaDeletadaEvent : Event
    {
        public Guid Id { get; set; }

        public DenunciaDeletadaEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
