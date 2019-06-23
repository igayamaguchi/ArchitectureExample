using DotNetECommerce.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Repositories
{
    public interface IMemberRepository
    {
        Member FindBy(string mailAddress);

        Member Create(string mailAddress, string password);

        Member Create(Member member);
    }
}
