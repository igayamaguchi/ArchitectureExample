using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Administrators
{
    public class Administrator
    {
        public Guid Id { get; private set; }

        public Administrator()
        {
            Id = Guid.NewGuid();
        }
    }
}
