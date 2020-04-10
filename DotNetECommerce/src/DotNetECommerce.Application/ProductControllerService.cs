using DotNetECommerce.Domain.Products;
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
        public SellResult Sell(int sellerId, string productName, decimal productPrice, int productPointRate)
        {
            var seller = sellerRepository.FindBy(sellerId);

            if (seller == null || seller.State != SellerState.Available)
            {
                // TODO: 承認済みでない場合のエラー
                return new SellResult { Type = SellResultType.NotFound };
            }

            // TODO: GUIDなどに
            var productId = new Random().Next();

            var product = Product.New(productId, productName, productPrice, productPointRate, seller);
            product.Sell();
            productRepository.Create(product);

            return new SellResult { Type = SellResultType.Ok, Product = product };
        }

        public FindResult FindBy(int productId)
        {
            var product = productRepository.FindBy(productId);

            if (product == null)
            {
                return new FindResult { Type = FindResultType.NotFound };
            }

            if (product.Seller.State != SellerState.Available)
            {
                return new FindResult { Type = FindResultType.NotAvailableSeller };
            }

            return new FindResult { Type = FindResultType.Ok, Product = product };
        }
    }

    public enum SellResultType
    {
        Ok,
        NotFound,
    }

    public class SellResult
    {
        public SellResultType Type { get; set; }
        public Product Product { get; set; }
    }

    public enum FindResultType
    {
        Ok,
        NotFound,
        NotAvailableSeller,
    }

    public class FindResult
    {
        public FindResultType Type { get; set; }
        public Product Product { get; set; }
    }
}
