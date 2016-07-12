namespace Domain.Persistence.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Persistence.EntityFramework.EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
