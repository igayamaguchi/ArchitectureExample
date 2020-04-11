using DotNetECommerce.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Products
{
    public class Product : IAggregateRoot
    {
        public Guid ProductId { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int PointRate { get; private set; }

        public Seller Seller { get; private set; }

        public ProductState State { get; private set; }

        protected Product(string name, decimal price, int pointRate, Seller seller, ProductState state)
        {
            this.ProductId = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
            this.PointRate = pointRate;
            this.Seller = seller;
            this.State = state;
        }

        public static Product New(string name, decimal price, int pointRate, Seller seller)
        {
            return new Product(name, price, pointRate, seller, ProductState.BeforeSale);
        }

        public Product Sell()
        {
            this.State = ProductState.Sale;
            return this;
        }

        public Product Discontinue()
        {
            this.State = ProductState.Discontinued;
            return this;
        }
    }
}
