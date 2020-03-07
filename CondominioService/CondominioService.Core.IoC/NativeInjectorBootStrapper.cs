using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CondominioService.Core.Communication.Mediator;
using CondominioService.Core.Data.EventSourcing;
using CondominioService.Core.Messages.CommonMessages.Notifications;
using EventSourcing;
using CondominioService.BuildingBlocks.Data.MongoDB.Connection;
using CondominioService.BuildingBlocks.Data.MongoDB.Interface.Connection;
using CondominioService.DenunciaContext.Data;
using CondominioService.DenunciaContext.Application.Interfaces;
using CondominioService.DenunciaContext.Application.Services;
using CondominioService.DenunciaContext.Application.Events;
using CondominioService.Core.Data;

namespace CondominioService.Core.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //MongoDB
            services.AddScoped<IConnect, Connect>();
            services.AddScoped<IConfig, Config>();

            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Event Sourcing
            services.AddScoped<IEventStoreService, EventStoreService>();
            services.AddScoped<IEventSourcingRepository, EventSourcingRepository>();

            //Denuncia
            services.AddScoped<CondominioService.DenunciaContext.Data.DenunciaContext>();

            //Repository
            services.AddScoped<IDenunciaRepository, DenunciaRepository>();

            // Application
            services.AddScoped<IDenunciaAppService, DenunciaAppService>();
        }
    }
}
