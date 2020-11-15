using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {

        private readonly StoreDbContext dbContext;

        public EFStoreRepository(StoreDbContext context)
        {
            dbContext = context;
        }

        public IQueryable<Product> Products => dbContext.Products.AsQueryable();
    }
}
