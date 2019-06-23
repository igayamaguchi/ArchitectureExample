using DotNetECommerce.Domain.Models;
using DotNetECommerce.Domain.Products;
using DotNetECommerce.Domain.Repositories;
using DotNetECommerce.Domain.Sellers;
using DotNetECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application
{
    public class ProductControllerService
    {
        private readonly IProductRepository productRepository;

        private readonly ISellerRepository sellerRepository;

        public ProductControllerService(IProductRepository productRepository, ISellerRepository sellerRepository)
        {
            this.productRepository = productRepository;
            this.sellerRepository = sellerRepository;
        }

        /// <summary>
        /// 商品の販売
        /// </summary>
        public SellResultType Sell(SellRequest request)
        {
            var seller = sellerRepository.FindBy(request.SellerId);

            if (seller == null || seller.State == SellerState.Available)
            {
                // TODO: 承認済みでない場合のエラー
                return SellResultType.NotFound;
            }

            var product = Product.New(request.ProductName, request.ProductPrice, request.ProductPointRate, seller);
            product.Sell();
            productRepository.Create(product);

            return SellResultType.Ok;
        }
    }

    public enum SellResultType
    {
        Ok,
        NotFound,
    }

    public class SellRequest
    {
        public int SellerId { get; set; }

        public string ProductName { get; private set; }

        public decimal ProductPrice { get; private set; }

        public int ProductPointRate { get; private set; }
    }
}
