using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetECommerce.ValueObject
{
    [Owned]
    public class MemberId
    {
        public MemberId(string memberId)
        {
            if (string.IsNullOrWhiteSpace(memberId))
            {
                throw new ArgumentException($"不正な値です：{memberId}");
            }
            this.Value = memberId;
        }

        protected MemberId() { }

        [Key]
        public string Value { get; private set; }
    }
}
