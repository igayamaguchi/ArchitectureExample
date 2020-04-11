using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public class ProductRepository : IProductRepository
    {
        public Product Find(Guid id)
        {
            return null;
        }

        public void Create(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
