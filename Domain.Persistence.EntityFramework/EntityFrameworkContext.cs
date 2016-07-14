using System.Data.Entity;
using Domain.Entities.Implementation;

namespace Domain.Persistence.EntityFramework
{
    public class EntityFrameworkContext: DbContext
    {
        public EntityFrameworkContext() : base("Default")
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}