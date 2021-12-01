using DomainDrivenDesingEFCore.Domain.Orders.Models;
using DomainDrivenDesingEFCore.Domain.SeedWork;
using DomainDrivenDesingEFCore.Persistence.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesingEFCore.Persistence.EFCore.Contexts
{
    public class OrderContext: DbContext
    {
        private readonly IEventDispatcher _eventDispatcher;

        

        public OrderContext(DbContextOptions<OrderContext> opt, IEventDispatcher eventDispatcher) :base(opt)
        {
            _eventDispatcher = eventDispatcher;
        }
        // eğer nesneler birbileri ile direk ilişkili ise aggregate olan nesnenin DbSet yazmak yeterli.
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            // veri tabanına kayıt atmadan önce eventleri dispatch etmem lazım

            _dispatchDomainEvents().GetAwaiter().GetResult();

            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dispatchDomainEvents();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private async Task _dispatchDomainEvents()
        {
            // entity üzerine tanımlanmış eklenmiş bir domain event varsa.
            var dEventEntites = ChangeTracker.Entries<IEntity>().Select(e => e.Entity).Where(e => e.DomainEvents.Any()).ToList();

            foreach (var item in dEventEntites)
            {
                foreach (var @event in item.DomainEvents)
                {
                    await _eventDispatcher.Dispatch(@event);
                }
            }
               
        }


    }
}
