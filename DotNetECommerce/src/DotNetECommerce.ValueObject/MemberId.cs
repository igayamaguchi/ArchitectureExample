using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.ValueObject
{
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

        public string Value { get; private set; }
    }
}
