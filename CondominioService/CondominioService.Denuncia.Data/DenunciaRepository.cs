using CondominioService.BuildingBlocks.Data.MongoDB;
using CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection;
using CondominioService.Core.Data;
using CondominioService.DenunciaContext.Application.Interfaces;
using CondominioService.DenunciaContext.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominioService.DenunciaContext.Data
{
    public class DenunciaRepository : Repository<Denuncia>, IDenunciaRepository
    {
        public DenunciaRepository(DenunciaContext context) : base(context)
        {

        }
        /* Para exemplo */
        //public IEnumerable<Denuncia> ObterTodasDenunciasAtivas()
        //{
        //    var filter = Builders<Denuncia>.Filter.Where(d => d.Inativo == false);
        //    return Db.Denuncias.Find(filter).ToList();
        //}
    }
}
