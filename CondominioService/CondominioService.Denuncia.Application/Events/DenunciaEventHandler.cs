using CondominioService.Core.Communication.Mediator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioService.DenunciaContext.Application.Events
{
    public class DenunciaEventHandler :
        INotificationHandler<DenunciaRegistradaEvent>,
        INotificationHandler<DenunciaAtualizadaEvent>,
        INotificationHandler<DenunciaDeletadaEvent>
    {

        private readonly IMediatorHandler _mediatorHandler;

        public DenunciaEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(DenunciaRegistradaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DenunciaAtualizadaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DenunciaDeletadaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
