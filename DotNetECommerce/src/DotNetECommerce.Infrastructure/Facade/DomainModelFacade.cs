using DotNetECommerce.Domain.Members;
using DotNetECommerce.Infrastructure.Utils;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DotNetECommerce.Infrastructure.Facade
{
    public class DomainModelFacade : DbContext
    {
        static DomainModelFacade()
        {
            //Database.SetInitializer(new SampleAppInitializer());
        }

        //public DomainModelFacade() : base("naa4e-09")
        //{
        //    Members = base.Set<Member>();
        //}

        public DomainModelFacade(DbContextOptions<DomainModelFacade> options)
            : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
    }
}
