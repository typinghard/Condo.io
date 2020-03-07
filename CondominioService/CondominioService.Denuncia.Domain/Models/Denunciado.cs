using CondominioService.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Models
{
    public class Denunciado
    {
        public Guid ResidenciaDenunciadoId { get; protected set; }
        public string Descricrao { get; protected set; }
    }
}
