using DotNetECommerce.Domain.Members;
using DotNetECommerce.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Repositories
{
    public interface IMemberRepository
    {
        Member FindBy(MailAddress mailAddress);

        Member Create(MailAddress mailAddress, Password password);

        Member Create(Member member);
    }
}
