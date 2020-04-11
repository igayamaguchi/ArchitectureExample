using DotNetECommerce.Domain.Administrators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetECommerce.Application.Test.Utils
{
    public class DummyAdministratorRepository : IAdministratorRepository
    {
        private Dictionary<Guid, Administrator> dummy = new Dictionary<Guid, Administrator>();

        public void Create(Administrator administrator)
        {
            dummy.Add(administrator.Id, administrator);
        }

        public Administrator FindBy(Guid id)
        {
            return dummy[id];
        }
    }
}
