using CondominioService.Core.Data;
using CondominioService.DenunciaContext.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Application.Interfaces
{
    public interface IDenunciaRepository : IRepository<Denuncia>
    {
    }
}
