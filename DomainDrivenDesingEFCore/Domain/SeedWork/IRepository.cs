using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.SeedWork
{
    public interface IRepository<TRootEntity> where TRootEntity:IAggregateRoot
    {
        void Add(TRootEntity rootEntity);
        void Update(TRootEntity rootEntity);
        void Delete(string key);
        void Save();
    }
}
