using DotNetECommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application
{
    public class MemberControllerService
    {
        public IMemberRepository memberRepository { get; private set; }

        public MemberControllerService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public SignUpResult SignUp(string mailAddress, string password)
        {
            var existMember = memberRepository.FindBy(mailAddress) != null;

            if (existMember)
            {
                return SignUpResult.ExistMember;
            }

            memberRepository.Create(mailAddress, password);
            return SignUpResult.Success;
        }
    }

    public enum SignUpResult
    {
        ExistMember,
        Success,
    }
}
