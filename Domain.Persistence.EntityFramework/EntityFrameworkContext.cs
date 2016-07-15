using System.Data.Entity;
using Domain.Persistence.EntityFramework.Conventions;
using Domain.Entities.Implementation;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.File;
using Domain.Entities.Implementation.Property;

namespace Domain.Persistence.EntityFramework
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext() : base("Default") { }
            
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DateTime2Convention());

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

            ConfigurePropertyOffer(modelBuilder);
        }

        private void ConfigurePropertyOffer(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyOffer>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<PropertyOffer>()
                        .HasRequired(x => x.Property)
                        .WithRequiredPrincipal();

            modelBuilder.Entity<Property>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Property>()
                .HasOptional(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Property>()
                .HasRequired(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                .HasOptional(x => x.District)
                .WithMany()
                .HasForeignKey(x => x.DistrictId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                        .HasMany(x => x.NearMetroStations)
                        .WithRequired()
                        .HasForeignKey(x => x.PropertyId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Property>()
                .HasMany(x => x.Photos)
                .WithRequired()
                .HasForeignKey(x => x.PropertyId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Property>()
                .HasMany(x => x.Documents)
                .WithRequired()
                .HasForeignKey(x => x.PropertyId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PropertyNearMetroStation>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<PropertyNearMetroStation>()
                .HasRequired(x => x.MetroStation)
                .WithMany()
                .HasForeignKey(x => x.MetroStationId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PropertyNearMetroStation>()
                .HasOptional(x => x.MetroBranch)
                .WithMany()
                .HasForeignKey(x => x.MetroBranchId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PropertyPhoto>()
                        .HasKey(x => new { x.PropertyId, x.FileId });

            modelBuilder.Entity<PropertyPhoto>()
                        .HasRequired(x => x.File)
                        .WithMany()
                        .HasForeignKey(x => x.FileId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<PropertyDocument>()
                        .HasKey(x => new { x.PropertyId, x.FileId });

            modelBuilder.Entity<PropertyDocument>()
                .HasRequired(x => x.File)
                .WithMany()
                .HasForeignKey(x => x.FileId)
                .WillCascadeOnDelete(true);
        }
    }
}