using DotNetECommerce.Domain.Members;
using DotNetECommerce.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Members
{
    public interface IMemberRepository
    {
        Member Find(Guid memberId);

        Member Find(MailAddress mailAddress);

        Member Create(MailAddress mailAddress, Password password);

        Member Create(Member member);

        void Delete(Member member);
    }
}
