using DotNetECommerce.Domain.Models;
using DotNetECommerce.Domain.Repositories;
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
        private SellerControllerService sellerControllerService;

        public SellerControllerServiceTest()
        {
            sellerRepository = new DummySellerRepository();
            administratorRepository = new DummyAdministratorRepository();

            sellerControllerService = new SellerControllerService(sellerRepository, administratorRepository);
        }

        [Fact]
        public void TestSignUp()
        {
            var seller = sellerControllerService.SignUp("mailaddress@example.com", "password", "Michel", "Example Company", "Japan");
            Assert.Equal(sellerRepository.FindBy(0), seller);
            Assert.Equal(SellerState.Applying, seller.State);
        }

        [Fact]
        public void TestApprove()
        {
            administratorRepository.Create(new Administrator { Id = 0 });
            var seller = sellerControllerService.SignUp("mailaddress@example.com", "password", "Michel", "Example Company", "Japan");
            sellerControllerService.Approve(seller.SellerId, 0);
            var actualSeller = sellerRepository.FindBy(seller.SellerId);
            Assert.Equal(seller, actualSeller);
            Assert.Equal(SellerState.Available, actualSeller.State);
        }
    }

    public class DummySellerRepository : ISellerRepository
    {
        private Dictionary<int, Seller> dummy = new Dictionary<int, Seller>();

        public void Create(Seller seller, string password)
        {
            dummy.Add(seller.SellerId, seller);
        }

        public Seller FindBy(int sellerId)
        {
            return dummy[sellerId];
        }

        public int FindNewId()
        {
            return 0;
        }

        public void Save(Seller seller, int administoratorId)
        {
            dummy[seller.SellerId] = seller;
        }
    }

    public class DummyAdministratorRepository : IAdministratorRepository
    {
        private Dictionary<int, Administrator> dummy = new Dictionary<int, Administrator>();

        public void Create(Administrator administrator)
        {
            dummy.Add(administrator.Id, administrator);
        }

        public Administrator FindBy(int id)
        {
            return dummy[id];
        }
    }
}