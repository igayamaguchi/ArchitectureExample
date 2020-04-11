using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application.Test.Utils
{
    public class DummyProductRepository : IProductRepository
    {
        private Dictionary<Guid, Product> dummy = new Dictionary<Guid, Product>();

        public void Create(Product product)
        {
            dummy.Add(product.ProductId, product);
        }

        public Product Find(Guid id)
        {
            return dummy[id];
        }
    }
}
