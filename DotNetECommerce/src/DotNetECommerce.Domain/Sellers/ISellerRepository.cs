using DotNetECommerce.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Sellers
{
    public interface ISellerRepository
    {
        Seller Find(Guid sellerId);
        void Create(Seller seller, string password);
        void Save(Seller seller, Guid administoratorId);
    }
}
