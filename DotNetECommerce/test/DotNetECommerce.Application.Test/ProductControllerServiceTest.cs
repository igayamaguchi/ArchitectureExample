using DotNetECommerce.Application.Test.Utils;
using DotNetECommerce.Domain.Products;
using DotNetECommerce.Domain.Sellers;
using DotNetECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DotNetECommerce.Application.Test
{
    public class ProductControllerServiceTest
    {
        private readonly AdministratorControllerService administratorControllerservice;
        private readonly SellerControllerService sellerControllerservice;
        private readonly ProductControllerService productControllerservice;

        public ProductControllerServiceTest()
        {
            var productRepository = new DummyProductRepository();
            var sellerRepository = new DummySellerRepository();
            var administratorRepository = new DummyAdministratorRepository();

            administratorControllerservice = new AdministratorControllerService(administratorRepository);
            sellerControllerservice = new SellerControllerService(sellerRepository, administratorRepository);
            productControllerservice = new ProductControllerService(productRepository, sellerRepository);
        }

        [Fact]
        public void SaleTest()
        {
            var administrator = administratorControllerservice.Create();
            var signUpSeller = sellerControllerservice.SignUp("test@example.com", "password", "representative name", "company name", "company address");
            var seller = sellerControllerservice.Approve(signUpSeller.SellerId, administrator.Id);

            var sellResult = productControllerservice.Sell(seller.SellerId, "product name", 1000, 5);
            var findResult = productControllerservice.FindBy(sellResult.Product.ProductId);
            Assert.Equal(ProductState.Sale, findResult.Product.State);
        }
    }
}
