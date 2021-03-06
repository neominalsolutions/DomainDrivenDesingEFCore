using DomainDrivenDesingEFCore.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.SeedWork
{
 
    public class MediatrDomainEventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MediatrDomainEventDispatcher> _log;
        public MediatrDomainEventDispatcher(IMediator mediator, ILogger<MediatrDomainEventDispatcher> log)
        {
            _mediator = mediator;
            _log = log;
        }

        public async Task Dispatch(IDomainEvent domainEvent)
        {

            var domainEventNotification = _createDomainEventNotification(domainEvent);
            _log.LogDebug("Dispatching Domain Event as MediatR notification.  EventType: {eventType}", domainEvent.GetType());
            // Publish ile InMemory Event fırlatabiliriz.
            await _mediator.Publish(domainEventNotification);
        }

        private INotification _createDomainEventNotification(IDomainEvent domainEvent)
        {
            var genericDispatcherType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
            return (INotification)Activator.CreateInstance(genericDispatcherType, domainEvent);

        }
    }
}
