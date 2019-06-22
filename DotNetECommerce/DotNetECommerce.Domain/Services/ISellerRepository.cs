using DotNetECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public interface ISellerRepository
    {
        Seller FindBy(int sellerId);
        void Create(Seller seller, string password, int administoratorId);
        void Save(Seller seller, int administoratorId);
    }
}
