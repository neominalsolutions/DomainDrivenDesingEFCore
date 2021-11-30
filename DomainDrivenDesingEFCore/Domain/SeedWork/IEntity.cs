using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.SeedWork
{
    // Bir şey entity ise domain event fırlatabilir.
    public interface IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}
