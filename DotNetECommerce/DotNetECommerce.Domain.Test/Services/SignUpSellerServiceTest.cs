using DotNetECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DotNetECommerce.Domain.Test.Services
{
    public class SignUpSellerServiceTest
    {
        [Fact]
        public void TestSignUp()
        {
            var service = new SignUpSellerService();
        }
    }
}
