using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Products
{
    public interface IProductRepository
    {
        Product FindBy(int id);

        void Create(Product product);
    }
}
