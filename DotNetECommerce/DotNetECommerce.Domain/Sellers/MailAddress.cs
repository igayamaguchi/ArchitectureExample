using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Sellers
{
    public class MailAddress
    {
        private readonly string value;

        public MailAddress(string value)
        {
            if (value.Length == 0)
            {
                throw new ArgumentException();
            }

            this.value = value;
        }
    }
}
