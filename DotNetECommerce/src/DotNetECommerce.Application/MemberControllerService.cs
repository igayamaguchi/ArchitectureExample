using DotNetECommerce.Domain.Repositories;
using DotNetECommerce.ValueObject;
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
            var m = new MailAddress(mailAddress);
            var p = new Password(password);

            var existMember = memberRepository.FindBy(m) != null;

            if (existMember)
            {
                return SignUpResult.ExistMember;
            }

            memberRepository.Create(m, p);
            return SignUpResult.Success;
        }
    }

    public enum SignUpResult
    {
        ExistMember,
        Success,
    }
}
