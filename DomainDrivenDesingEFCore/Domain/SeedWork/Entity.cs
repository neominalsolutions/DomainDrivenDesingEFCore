using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();


        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        // Entity için event ekleme event tanımlama kavramı
        public void AddEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }


        public void RemoveEvent(IDomainEvent @event)
        {
            _domainEvents.Remove(@event);
        }
    }
}
