using DotNetECommerce.Domain.Models;
using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Repositories
{
    public interface IProductRepository
    {
        Product FindBy(int id);

        Product Create(Product product);
    }
}
