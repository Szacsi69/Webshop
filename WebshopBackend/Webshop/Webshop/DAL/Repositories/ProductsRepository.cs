using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;
using Webshop.Models;

namespace Webshop.DAL.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public ProductsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product> GetById(int productId)
        {
            var product = await _ctx.Products.Where(p => p.Id == productId).SingleOrDefaultAsync();
            if (product == null)
                return null;
            else
                return ToModel(product);
        }

        public async Task<Product> RemoveProductItem(int productId, int amount)
        {
            using (var tran = _ctx.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                var product = await _ctx.Products.Where(p => p.Id == productId).SingleOrDefaultAsync();
                if (amount > product.Amount)
                {
                    tran.Commit();
                    return null;
                }
                else if (amount == product.Amount)
                {
                    _ctx.Products.Remove(product);
                    _ctx.SaveChanges();
                }
                else
                {
                    product.Amount -= amount;
                    _ctx.SaveChanges();
                }
                tran.Commit();
                return ToModel(product);
            }
        }

        private static Product ToModel(DbProduct entity)
        {
            return new Product(entity);
        }
    }
}
