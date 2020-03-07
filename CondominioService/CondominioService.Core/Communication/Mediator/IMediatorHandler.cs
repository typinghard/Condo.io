﻿using System.Threading.Tasks;
using CondominioService.Core.Messages;
using CondominioService.Core.Messages.CommonMessages.DomainEvents;
using CondominioService.Core.Messages.CommonMessages.Notifications;

namespace CondominioService.Core.Communication.Mediator
{
   public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}
