using DotNetECommerce.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Sellers
{
    public interface ISellerRepository
    {
        int FindNewId();
        Seller FindBy(int sellerId);
        void Create(Seller seller, string password);
        void Save(Seller seller, int administoratorId);
    }
}
