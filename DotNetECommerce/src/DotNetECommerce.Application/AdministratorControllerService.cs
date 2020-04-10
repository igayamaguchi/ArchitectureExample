using DotNetECommerce.Domain.Administrators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetECommerce.Application
{
    public class AdministratorControllerService
    {
        private readonly IAdministratorRepository administratorRepository;

        public AdministratorControllerService(IAdministratorRepository administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }

        public Administrator Create()
        {
            // TODO: GUIDに
            var id = administratorRepository.FindNewId();
            var administrator = new Administrator { Id = id };
            administratorRepository.Create(administrator);
            return administrator;
        }
    }
}
