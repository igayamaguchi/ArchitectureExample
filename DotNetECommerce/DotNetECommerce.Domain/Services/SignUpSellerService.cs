using DotNetECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public class SignUpSellerService
    {
        public void SignUp(Seller seller)
        {
            seller.SignUp();
        }
    }
}
