using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Domain.SeedWork
{

    public interface IReadOnlyRepository
    {

    }


    public interface IRepository<TRootEntity> where TRootEntity:Entity, IAggregateRoot
    {
        //void Add(TRootEntity rootEntity);
        //void Update(TRootEntity rootEntity);
        //void Delete(string key);
        //void Save();

        Task<TRootEntity> FindByIdAsync(string key);
        Task<IEnumerable<TRootEntity>> FindAsync(ISpecification<TRootEntity> specification = null);

        Task<IEnumerable<TRootEntity>> FindAsync(Expression<Func<TRootEntity, bool>> predicate = null);

        Task AddAsync(TRootEntity rootEntity);

        // bulk insert
        Task AddRangeAsync(IEnumerable<TRootEntity> entities);

        // Soft Delete
        // IsDeleted alatına göre
        Task RemoveAsync(string Id);
        Task RemoveRangeAsync(params string[] ids);

        Task UpdateAsync(TRootEntity rootEntity);

        Task<bool> ContainsAsync(ISpecification<TRootEntity> specification = null);

        Task<bool> ContainsAsync(Expression<Func<TRootEntity,bool>> predicate = null);

        Task<int> CountAsync(ISpecification<TRootEntity> specification = null);

        Task<bool> CountAsync(Expression<Func<TRootEntity, bool>> predicate = null);

        // Hard Delete
        Task DeleteAsync(string Id);
        Task DeleteRangeAsync(params string[] ids);

        Task SaveAsync();



    }
}
