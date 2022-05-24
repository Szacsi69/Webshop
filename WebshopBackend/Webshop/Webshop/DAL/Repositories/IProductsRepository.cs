using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.DAL.Repositories
{
    public interface IProductsRepository
    {
        public Task<Product> GetById(int productId);
        public Task<Product> RemoveProductItem(int productId, int amount);
    }
}
