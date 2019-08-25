using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.ValueObject
{
    public class Password
    {
        private readonly string value;

        public Password(string password)
        {
            if (password.Length == 0)
            {
                throw new ArgumentException();
            }

            this.value = password;
        }

        public string Value { get => this.value; }
    }
}
