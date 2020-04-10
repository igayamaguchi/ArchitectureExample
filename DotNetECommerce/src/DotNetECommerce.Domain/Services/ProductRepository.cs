using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public class ProductRepository : IProductRepository
    {
        public Product FindBy(int id)
        {
            return null;
        }

        public void Create(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
