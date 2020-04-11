using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Administrators
{
    public interface IAdministratorRepository
    {
        void Create(Administrator administrator);
        Administrator FindBy(Guid id);
    }
}
