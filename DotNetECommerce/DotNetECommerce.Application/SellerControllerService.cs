using DotNetECommerce.Domain.Models;
using DotNetECommerce.Domain.Services;
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

        public Seller SignUp(string mailAddress, string password, string representativeName, string companyName, string companyAddress, int administratorId)
        {
            var seller = Seller.SignUp(mailAddress, representativeName, companyName, companyAddress);
            // TODO: idはGuidに？
            var administrator = administratorRepository.FindBy(administratorId);

            if (administrator == null)
            {
                throw new ArgumentException("管理者が見つかりません");
            }

            sellerRepository.Create(seller, password, administrator.Id);
            return seller;
        }

        public Seller Approve(int sellerId, int administratorId)
        {
            var seller = sellerRepository.FindBy(sellerId);
            // これはだめ、事前条件の認証などがうまく機能していない
            seller.Activate();
            sellerRepository.Save(seller, administratorId);
            return seller;
        }
    }
}
