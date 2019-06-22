using DotNetECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Domain.Services
{
    public interface IAdministratorRepository
    {
        Administrator FindBy(int id);
    }
}
