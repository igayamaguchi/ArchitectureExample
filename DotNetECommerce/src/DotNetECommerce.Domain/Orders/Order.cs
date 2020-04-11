using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Orders
{
    public class Order : IAggregateRoot
    {
        /**
         * 商品購入時には料金を支払い、発送者、発送先住所を入力する。
         * 注文には会員登録は不要。
         * 会員登録しているとポイントを受け取ることが出来る。
         * 会員登録をせず注文をする場合はメールアドレスが必要。
         */

        public Guid OrderId { get; private set; }

        public DateTime OrderedOn { get; private set; }

        public Guid ProductId { get; private set; }

        public Guid MemberId { get; private set; }

        public string MailAddress { get; private set; }

        protected Order()
        {
            OrderId = Guid.NewGuid();
            OrderedOn = DateTime.Now;
        }

        public Order Create(Guid productId)
        {
            // TODO: WIP
            return null;
        }
    }
}
