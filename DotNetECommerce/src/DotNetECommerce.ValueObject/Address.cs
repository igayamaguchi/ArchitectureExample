using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.ValueObject
{
    public class Address
    {
        private readonly Prefecture prefecture;
        private readonly string city;
        private readonly PostCode postCode;
        private readonly string belowAddress;

        public Address(Prefecture prefecture, string city, PostCode postCode, string belowAddress)
        {
            this.prefecture = prefecture;
            this.city = city;
            this.postCode = postCode;
            this.belowAddress = belowAddress;
        }
    }
}
