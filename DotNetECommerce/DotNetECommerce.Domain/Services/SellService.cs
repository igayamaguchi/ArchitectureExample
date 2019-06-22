using DotNetECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public class SellService : ISellService
    {
        public Product Sell(Product product)
        {
            var saleProduct = product.Sell();
            return saleProduct;
        }
    }
}
