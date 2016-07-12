using System.IO;
using System.Linq;
using Domain.Entities.Implementation.City;

namespace Domain.Persistence.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Persistence.EntityFramework.EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkContext context)
        {
            if (!context.Cities.Any())
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(@"/SQL/cities.sql"));

                //context.SaveChanges();
            }

          

            base.Seed(context);
        }
    }
}
