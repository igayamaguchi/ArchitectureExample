using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application.Test.Utils
{
    public class DummyProductRepository : IProductRepository
    {
        private Dictionary<int, Product> dummy = new Dictionary<int, Product>();

        public void Create(Product product)
        {
            dummy.Add(product.ProductId, product);
        }

        public Product FindBy(int id)
        {
            return dummy[id];
        }
    }
}
