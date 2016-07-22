using System.Diagnostics;
using System.IO;
using System.Linq;
using Domain.Entities.Implementation.City;

namespace Domain.Persistence.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Persistence.EntityFramework.EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EntityFrameworkContext context)
        {
            context.Database.ExecuteSqlCommand(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/SQL/cities.sql"));
            base.Seed(context);
        }
    }
}
