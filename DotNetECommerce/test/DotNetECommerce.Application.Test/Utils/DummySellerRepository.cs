using DotNetECommerce.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetECommerce.Application.Test.Utils
{
    public class DummySellerRepository : ISellerRepository
    {
        private Dictionary<Guid, Seller> dummy = new Dictionary<Guid, Seller>();

        public void Create(Seller seller, string password)
        {
            dummy.Add(seller.SellerId, seller);
        }

        public Seller FindBy(Guid sellerId)
        {
            return dummy[sellerId];
        }

        public void Save(Seller seller, Guid administoratorId)
        {
            dummy[seller.SellerId] = seller;
        }
    }
}
