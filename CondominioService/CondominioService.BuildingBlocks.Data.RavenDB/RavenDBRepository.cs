//using CondominioService.Core.Data;
//using CondominioService.Core.DomainObjects;
//using System;

//namespace CondominioService.BuildingBlocks.Data.RavenDB
//{
//    public class RavenDBRepository<T> : IRavenRepository<T> where T : IAggregateRoot
//    {
//        public RavenDBRepository()
//        {

//        }

//        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

//        public void Dispose()
//        {
//            GC.SuppressFinalize(this);
//        }
//    }
//}
