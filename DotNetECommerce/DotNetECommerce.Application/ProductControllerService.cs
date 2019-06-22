using DotNetECommerce.Domain.Models;
using DotNetECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application
{
    public class ProductControllerService
    {
        private readonly IProductRepository productRepository;

        private readonly ISellService sellService;

        public ProductControllerService(IProductRepository productRepository, ISellService sellService)
        {
            this.productRepository = productRepository;
            this.sellService = sellService;
        }

        /// <summary>
        /// 商品の販売
        /// </summary>
        public SellResultType Sell(SellRequest request, Seller seller)
        {
            var product = productRepository.FindBy(request.ProductId);

            if (product == null)
            {
                return SellResultType.NotFound;
            }

            var sellerProduct = sellService.Sell(product);

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
        public int ProductId { get; set; }
    }
}
