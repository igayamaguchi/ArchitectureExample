using DotNetECommerce.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public interface IMemberService
    {
        void Delete(Member member);
    }
}
