using DotNetECommerce.Domain.Models;
using DotNetECommerce.Domain.Repositories;
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

        public Seller FindBy(int sellerId)
        {
            throw new NotImplementedException();
        }

        public void Save(Seller seller, int administoratorId)
        {
            throw new NotImplementedException();
        }
    }
}
