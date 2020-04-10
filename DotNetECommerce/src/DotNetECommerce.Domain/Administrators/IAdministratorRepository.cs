using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Administrators
{
    public interface IAdministratorRepository
    {
        int FindNewId();
        void Create(Administrator administrator);
        Administrator FindBy(int id);
    }
}
