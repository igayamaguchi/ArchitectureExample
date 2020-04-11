using DotNetECommerce.Domain.Sellers;
using DotNetECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        public void Create(Seller seller, string password)
        {
            // TODO
        }

        public Seller FindBy(Guid sellerId)
        {
            throw new NotImplementedException();
        }

        public void Save(Seller seller, Guid administoratorId)
        {
            throw new NotImplementedException();
        }
    }
}
