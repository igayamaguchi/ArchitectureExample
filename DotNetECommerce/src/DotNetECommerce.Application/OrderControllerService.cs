using DotNetECommerce.Domain.Members;
using DotNetECommerce.Domain.Orders;
using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application
{
    public class OrderControllerService
    {
        private readonly IMemberRepository memberRepository;
        private readonly IProductRepository productRepository;

        public OrderControllerService(IMemberRepository memberRepository, IProductRepository productRepository)
        {
            this.memberRepository = memberRepository;
            this.productRepository = productRepository;
        }

        public OrderResult Order(Guid productId)
        {
            // TODO: WIP
            var product = productRepository.Find(productId);

            if (product == null)
            {
                return new OrderResult { ResultType = OrderResultType.NotFoundProduct };
            }


            return new OrderResult { ResultType = OrderResultType.Success, Order = null };
        }

        public void Order(Guid memberId, Guid productId)
        {
            // TODO: WIP
            var member = memberRepository.Find(memberId);
            if (member == null)
            {

            }

            if (member.State != MemberState.Registered)
            {

            }

        }
    }

    public enum OrderResultType
    {
        Success,
        NotFoundMmeber,
        NotFoundProduct,
    }

    public class OrderResult
    {
        public OrderResultType ResultType { get; set; }
        public Order Order { get; set; }
    }
}
