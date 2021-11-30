using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.SeedWork
{
    public interface IEventDispatcher
    {
        /// <summary>
        /// Domain Eventleri sevk eder
        /// </summary>
        /// <param name="dEvent"></param>
        /// <returns></returns>
        Task Dispatch(IDomainEvent dEvent);
    }
}
