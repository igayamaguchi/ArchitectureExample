using DotNetECommerce.Domain.Members;
using DotNetECommerce.Domain.Services;
using DotNetECommerce.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application
{
    public class MemberControllerService
    {
        private readonly IMemberService memberService;
        private readonly IMemberRepository memberRepository;

        public MemberControllerService(IMemberService memberService, IMemberRepository memberRepository)
        {
            this.memberService = memberService;
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

        public DeleteResult Delete(string memberId)
        {
            // TODO: ログイン状態の確認
            var id = new MemberId(memberId);
            var member = memberRepository.FindBy(id);

            if (member != null) return DeleteResult.NotExistMember;

            member.Delete();
            memberRepository.Delete(member);

            // TODO: メール通知

            return DeleteResult.Success;
        }
    }

    public enum SignUpResult
    {
        Success,
        ExistMember,
    }

    public enum DeleteResult
    {
        Success,
        NotExistMember,
        AlreadyDeleted,
    }
}
