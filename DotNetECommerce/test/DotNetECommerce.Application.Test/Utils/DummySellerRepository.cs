using DotNetECommerce.Domain.Sellers;
using System.Collections.Generic;
using System.Linq;

namespace DotNetECommerce.Application.Test.Utils
{
    public class DummySellerRepository : ISellerRepository
    {
        private static Dictionary<int, Seller> dummy = new Dictionary<int, Seller>();

        public void Create(Seller seller, string password)
        {
            dummy.Add(seller.SellerId, seller);
        }

        public Seller FindBy(int sellerId)
        {
            return dummy[sellerId];
        }

        public int FindNewId()
        {
            if (dummy.Keys.Count() == 0) return 0;
            return dummy.Keys.Last() + 1;
        }

        public void Save(Seller seller, int administoratorId)
        {
            dummy[seller.SellerId] = seller;
        }
    }
}
