using DotNetECommerce.Application.Test.Utils;
using DotNetECommerce.Domain.Administrators;
using DotNetECommerce.Domain.Sellers;
using DotNetECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DotNetECommerce.Application.Test
{
    public class SellerControllerServiceTest
    {
        private ISellerRepository sellerRepository;
        private IAdministratorRepository administratorRepository;
        private AdministratorControllerService administratorControllerService;
        private SellerControllerService sellerControllerService;

        public SellerControllerServiceTest()
        {
            sellerRepository = new DummySellerRepository();
            administratorRepository = new DummyAdministratorRepository();

            administratorControllerService = new AdministratorControllerService(administratorRepository);
            sellerControllerService = new SellerControllerService(sellerRepository, administratorRepository);
        }

        [Fact]
        public void TestSignUp()
        {
            var seller = sellerControllerService.SignUp("mailaddress@example.com", "password", "Michel", "Example Company", "Japan");
            Assert.Equal(sellerRepository.FindBy(seller.SellerId), seller);
            Assert.Equal(SellerState.Applying, seller.State);
        }

        [Fact]
        public void TestApprove()
        {
            var administrator = administratorControllerService.Create();
            var seller = sellerControllerService.SignUp("mailaddress@example.com", "password", "Michel", "Example Company", "Japan");
            sellerControllerService.Approve(seller.SellerId, administrator.Id);
            var actualSeller = sellerRepository.FindBy(seller.SellerId);
            Assert.Equal(seller, actualSeller);
            Assert.Equal(SellerState.Available, actualSeller.State);
        }
    }
}