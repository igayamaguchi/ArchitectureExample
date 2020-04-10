using DotNetECommerce.Domain.Administrators;
using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Sellers
{
    public class Seller : IAggregateRoot
    {
        public int SellerId { get; private set; }

        public string MailAddress { get; private set; }

        private readonly string representativeName;

        private readonly string companyName;

        private readonly string companyAddress;

        public SellerState State { get; private set; }

        public int? AdministratorId { get; private set; }

        public IEnumerable<Product> Products;

        protected Seller(int sellerId, string mailAddress, string representativeName, string companyName, string companyAddress, SellerState state)
        {
            this.SellerId = sellerId;
            this.MailAddress = mailAddress;
            this.representativeName = representativeName;
            this.companyName = companyName;
            this.companyAddress = companyAddress;
            this.State = state;
            this.AdministratorId = null;
        }

        public static Seller SignUp(int sellerId, string mailAddress, string representativeName, string companyName, string companyAddress)
        {
            return new Seller(sellerId, mailAddress, representativeName, companyName, companyAddress, SellerState.Applying);
        }

        public Seller Activate(Administrator administrator)
        {
            if (State != SellerState.Applying)
            {
                throw new InvalidOperationException("申請中ではないので承認できません。");
            }
            AdministratorId = administrator.Id;
            State = SellerState.Available;
            return this;
        }
    }
}
