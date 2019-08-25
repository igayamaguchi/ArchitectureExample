using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Members
{
    public class Member : IAggregateRoot
    {
        public string MailAddress { get; private set; }

        public string Name { get; set; }

        public string Telephone { get; set; }
    }
}
