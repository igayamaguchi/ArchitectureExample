using DotNetECommerce.Domain.Members;
using DotNetECommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public class MemberService : IMemberService
    {
        public IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public void Delete(Member member)
        {
            member.Delete();
            memberRepository.Delete(member);
        }
    }
}
