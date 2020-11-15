using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Task SaveOrder(Order order);
        Task SaveOrderAsync(Order order);
    }
    public class EFOrderRepository : IOrderRepository
    {
        private readonly StoreDbContext dbContext;
        public EFOrderRepository(StoreDbContext context)
        {
            dbContext = context;
        }
        public IQueryable<Order> Orders => dbContext.Orders;
        public Task SaveOrder(Order order)
        {
            return SaveOrderAsync(order);
        }
        public async Task SaveOrderAsync(Order order)
        {
            dbContext.AttachRange(order.Lines.Select(l => l.Product));
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
