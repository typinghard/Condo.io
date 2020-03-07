using CondominioService.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Application.Events
{
    public class DenunciaAtualizadaEvent : Event
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }
        public DenunciaAtualizadaEvent(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            AggregateId = id;
        }

    }
}
