using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.ValueObject
{
    public class MailAddress
    {
        private readonly string value;

        public MailAddress(string mailAddress)
        {
            if (mailAddress.Length == 0)
            {
                throw new ArgumentException();
            }

            this.value = mailAddress;
        }

        public string Value { get => this.value; }
    }
}
