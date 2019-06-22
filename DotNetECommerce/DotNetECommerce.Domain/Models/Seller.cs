using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Models
{
    public class Seller
    {
        private readonly string mailAddress;

        // これは照合時のみ
        //private readonly string password;

        private readonly string representativeName;

        private readonly string companyName;

        private readonly string companyAddress;

        private SellerState state;

        public IEnumerable<Product> products;

        protected Seller(string mailAddress, string representativeName, string companyName, string companyAddress, SellerState state)
        {
            this.mailAddress = mailAddress;
            this.representativeName = representativeName;
            this.companyName = companyName;
            this.companyAddress = companyAddress;
            this.state = state;
        }

        public static Seller SignUp(string mailAddress, string representativeName, string companyName, string companyAddress)
        {
            return new Seller(mailAddress, representativeName, companyName, companyAddress, SellerState.Applying);
        }

        public Seller Activate()
        {
            this.state = SellerState.Available;
            return this;
        }
    }
}
