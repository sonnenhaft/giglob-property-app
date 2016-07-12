using System.Data.Entity;
using Domain.Entities.Implementation;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.File;

namespace Domain.Persistence.EntityFramework
{
    public class EntityFrameworkContext: DbContext
    {
        public EntityFrameworkContext(): base("Default") { }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<City>()
                        .HasMany(x => x.Districts)
                        .WithRequired()
                        .HasForeignKey(x => x.CityId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<City>()
                        .HasMany(x => x.MetroStations)
                        .WithRequired()
                        .HasForeignKey(x => x.CityId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                        .HasMany(x => x.MetroBranches)
                        .WithRequired()
                        .HasForeignKey(x => x.CityId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<District>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MetroStation>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MetroStation>()
                        .HasMany(x => x.Branches)
                        .WithMany()
                        .Map(configuration => configuration.MapLeftKey("StationId")
                                                           .MapRightKey("BranchId")
                                                           .ToTable("MetroStationToMetroBranchRelations"));

            modelBuilder.Entity<MetroBranch>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<File>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<File>()
                        .Ignore(x => x.Stream);
        }
    }
}