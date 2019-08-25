using DotNetECommerce.Domain.Models;
using DotNetECommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Sellers
{
    public class Seller : IAggregateRoot
    {
        private readonly string mailAddress;

        private readonly string representativeName;

        private readonly string companyName;

        private readonly string companyAddress;

        public SellerState State { get; private set; }

        public Administrator Administrator { get; private set; }

        public IEnumerable<Product> Products;

        protected Seller(string mailAddress, string representativeName, string companyName, string companyAddress, SellerState state, Administrator administrator)
        {
            this.mailAddress = mailAddress;
            this.representativeName = representativeName;
            this.companyName = companyName;
            this.companyAddress = companyAddress;
            this.State = state;
            this.Administrator = administrator;
        }

        public static Seller SignUp(string mailAddress, string representativeName, string companyName, string companyAddress, Administrator administrator)
        {
            return new Seller(mailAddress, representativeName, companyName, companyAddress, SellerState.Applying, administrator);
        }

        public Seller Activate(Administrator administrator)
        {
            if (State != SellerState.Applying)
            {
                throw new InvalidOperationException("申請中ではないので承認できません。");
            }
            Administrator = administrator;
            State = SellerState.Available;
            return this;
        }
    }
}
