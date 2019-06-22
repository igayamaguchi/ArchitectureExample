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

        private readonly ProductState state;

        public Product(string name, decimal price, int pointRate, Seller seller, ProductState state)
        {
            this.name = name;
            this.price = price;
            this.pointRate = pointRate;
            this.seller = seller;
            this.state = state;
        }

        public Product Sell()
        {
            return new Product(this.name, this.price, this.pointRate, this.seller, ProductState.Sale);
        }

        public Product Discontinue()
        {
            return new Product(this.name, this.price, this.pointRate, this.seller, ProductState.Discontinued);
        }
    }
}
