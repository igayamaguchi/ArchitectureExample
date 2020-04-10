using DotNetECommerce.Domain.Administrators;
using DotNetECommerce.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application
{
    public class SellerControllerService
    {
        private readonly ISellerRepository sellerRepository;
        private readonly IAdministratorRepository administratorRepository;

        public SellerControllerService(ISellerRepository sellerRepository, IAdministratorRepository administratorRepository)
        {
            this.sellerRepository = sellerRepository;
            this.administratorRepository = administratorRepository;
        }

        public Seller SignUp(string mailAddress, string password, string representativeName, string companyName, string companyAddress)
        {
            var newSellerId = sellerRepository.FindNewId();
            var seller = Seller.SignUp(newSellerId, mailAddress, representativeName, companyName, companyAddress);
            sellerRepository.Create(seller, password);
            return seller;
        }

        public Seller Approve(int sellerId, int administratorId)
        {
            var administrator = administratorRepository.FindBy(administratorId);

            if (administrator == null)
            {
                throw new InvalidOperationException("管理者が見つかりません");
            }
            var seller = sellerRepository.FindBy(sellerId);

            if (seller == null)
            {
                throw new InvalidOperationException("販売者が見つかりません");
            }

            seller.Activate(administrator);
            sellerRepository.Save(seller, administratorId);
            return seller;
        }
    }
}
