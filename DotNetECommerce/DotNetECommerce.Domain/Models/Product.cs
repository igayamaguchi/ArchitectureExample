using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Models
{
    public class Product
    {
        private readonly string name;

        private readonly decimal price;

        private readonly int pointRate;

        private readonly Seller seller;
    }
}
