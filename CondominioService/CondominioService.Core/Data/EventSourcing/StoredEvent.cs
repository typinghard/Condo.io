﻿using System;

namespace CondominioService.Core.Data.EventSourcing
{
    public class StoredEvent
    {
        public StoredEvent(Guid id, Guid aggregatedId, string tipo, DateTime dataOcorrencia, string dados)
        {
            Id = id;
            AggregatedId = aggregatedId;
            Tipo = tipo;
            DataOcorrencia = dataOcorrencia;
            Dados = dados;
        }

        public Guid Id { get; private set; }

        public Guid AggregatedId { get; private set; }

        public string Tipo { get; private set; }

        public DateTime DataOcorrencia { get; set; }

        public string Dados { get; private set; }
    }
}
