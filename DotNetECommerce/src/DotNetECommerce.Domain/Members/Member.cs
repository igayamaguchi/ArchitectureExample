using DotNetECommerce.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetECommerce.Domain.Members
{
    public class Member : IAggregateRoot
    {
        [Key]
        //public MemberId MemberId { get; private set; }
        public string MemberId { get; private set; }

        public MailAddress MailAddress { get; private set; }

        public string Name { get; private set; }

        public string Telephone { get; private set; }

        public string Address { get; private set; }

        public MemberState State { get; private set; }

        public Member(MailAddress mailAddress, string name, string telephone = null, string address = null)
        {
            this.MailAddress = mailAddress;
            this.Name = name;
            this.Telephone = telephone;
            this.Address = address;
            this.State = MemberState.Unregistered;
        }

        protected Member() { }

        public void Delete()
        {
            if (State != MemberState.Registered)
                throw new InvalidOperationException($"登録中以外のユーザーを退会させようとしました。：{MemberId}");
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
