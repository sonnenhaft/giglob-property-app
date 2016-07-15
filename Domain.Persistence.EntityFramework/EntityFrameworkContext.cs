using System.Data.Entity;
using Domain.Entities.User.Implementation;
using Domain.Persistence.EntityFramework.Conventions;
using Domain.Entities.Implementation;
using Domain.Entities.Implementation.City;

namespace Domain.Persistence.EntityFramework
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext() : base("Default") { }
            
        public DbSet<City> Cities { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DateTime2Convention());

            modelBuilder.Entity<City>()
                        .HasKey(x => x.Id);
        }
    }
}