using System.Data.Entity;
using Domain.Persistence.EntityFramework.Conventions;

namespace Domain.Persistence.EntityFramework
{
    public class EntityFrameworkContext: DbContext
    {
        public EntityFrameworkContext() : base("Default")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DateTime2Convention());
        }
    }
}