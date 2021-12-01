using DomainDrivenDesingEFCore.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Infrastructure.Persistences.EFCore
{
    public abstract class EFBaseRepository<TContext, TEntity> : IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
        where TContext:DbContext
    {
        protected readonly TContext _context; // database bağlantısı sağlar
        protected readonly DbSet<TEntity> _dbSet; // tipi göre ilgili entity bağlanmamızı sağlar


        public EFBaseRepository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

            //_dbSet.EntityType.FindPrimaryKey()

        }


        public virtual async Task AddAsync(TEntity rootEntity)
        {
            await _dbSet.AddAsync(rootEntity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            

            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task<bool> ContainsAsync(ISpecification<TEntity> specification = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> CountAsync(ISpecification<TEntity> specification = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(string Id)
        {
            var entity =  await _dbSet.FindAsync(Id);
            entity.IsDeleted = true;

            await UpdateAsync(entity);
        }

        public virtual async Task DeleteRangeAsync(params string[] ids)
        {
            throw new NotImplementedException();
        }

        private async Task<IQueryable<TEntity>> ApplySpecification(ISpecification<TEntity> spec)
        {

    
            var query = _dbSet.Where(x => x.IsDeleted == false).AsQueryable();

            return SpecificationEvaluator<TEntity>.GetQuery(query,spec);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification = null)
        {
            return await ApplySpecification(specification);
        }

        public virtual async Task<TEntity> FindByIdAsync(string key)
        {
           return await _dbSet.FindAsync(key);
        }
        

        public virtual async Task RemoveAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task RemoveRangeAsync(params string[] ids)
        {
            throw new NotImplementedException();
        }

        public virtual async Task SaveAsync()
        {
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(TEntity rootEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }
    }
}
