﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CriadoAs { get; protected set; }
        public DateTime AtualizadoAs { get; protected set; }

        public bool Inativo { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public void Inativar()
        {
            DefinirDataAtualizacao();
            Inativo = true;
        }

        public void DefinirDataCriacao()
        {
            CriadoAs = AtualizadoAs = DateTime.Now;
        }
        public void DefinirDataAtualizacao()
        {
            AtualizadoAs = DateTime.Now;
        }
    }
}
