using DotNetECommerce.Domain.Administrators;
using System.Collections.Generic;
using System.Linq;

namespace DotNetECommerce.Application.Test.Utils
{
    public class DummyAdministratorRepository : IAdministratorRepository
    {
        private Dictionary<int, Administrator> dummy = new Dictionary<int, Administrator>();

        public void Create(Administrator administrator)
        {
            dummy.Add(administrator.Id, administrator);
        }

        public Administrator FindBy(int id)
        {
            return dummy[id];
        }

        public int FindNewId()
        {
            if (dummy.Keys.Count() == 0) return 0;
            return dummy.Keys.Last() + 1;
        }
    }
}
