using DotNetECommerce.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Members
{
    public class Member : IAggregateRoot
    {
        public MemberId MemberId { get; private set; }

        public MailAddress MailAddress { get; private set; }

        public string Name { get; private set; }

        public string Telephone { get; private set; }

        public string Address { get; private set; }

        public MemberState State { get; private set; }

        public Member()
        {
            this.State = MemberState.Unregistered;
        }

        public void Delete()
        {
            if (State != MemberState.Registered)
                throw new InvalidOperationException($"登録中以外のユーザーを退会させようとしました。：{MemberId.Value}");
            this.State = MemberState.Deleted;
        }
    }

    public enum MemberState
    {
        Unregistered = 0,
        Registered = 1,
        Deleted = 2, // 退会
    }
}
