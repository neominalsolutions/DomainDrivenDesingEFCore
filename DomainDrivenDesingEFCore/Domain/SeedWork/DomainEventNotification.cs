using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.SeedWork
{
  

    /// <summary>
    /// fırlatılacak olan evenlerimizin tipini verdik.
    /// </summary>
    /// <typeparam name="TDomainEvent"></typeparam>
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : IDomainEvent
    {
        public TDomainEvent DomainEvent { get; }

        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
