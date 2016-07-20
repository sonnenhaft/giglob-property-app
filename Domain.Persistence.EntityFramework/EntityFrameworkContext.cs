using System.Data.Entity;
using Domain.Entities.User.Implementation;
using Domain.Persistence.EntityFramework.Conventions;
using Domain.Entities.Implementation;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.File;
using Domain.Entities.Implementation.PropertyOffer;

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

            modelBuilder.Entity<MetroStationToMetroBranchRelations>()
                       .HasKey(x => new {x.MetroStationId, x.MetroBranchId });

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
                        .HasOptional(x => x.LocalPropertyOfferData)
                        .WithRequired()
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<PropertyOffer>()
                        .HasOptional(x => x.ExternalPropertyOfferData)
                        .WithRequired()
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<LocalPropertyOfferData>()
                        .HasKey(x => x.PropertyOfferId);

            modelBuilder.Entity<LocalPropertyOfferData>()
                .HasOptional(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<LocalPropertyOfferData>()
                .HasRequired(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocalPropertyOfferData>()
                .HasOptional(x => x.District)
                .WithMany()
                .HasForeignKey(x => x.DistrictId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocalPropertyOfferData>()
                        .HasMany(x => x.NearMetroStations)
                        .WithRequired()
                        .HasForeignKey(x => x.PropertyOfferId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<LocalPropertyOfferData>()
                .HasMany(x => x.Photos)
                .WithRequired()
                .HasForeignKey(x => x.PropertyOfferId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<LocalPropertyOfferData>()
                .HasMany(x => x.Documents)
                .WithRequired()
                .HasForeignKey(x => x.PropertyOfferId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ExternalPropertyOfferData>()
                        .HasKey(x => x.PropertyOfferId);

            modelBuilder.Entity<ExternalPropertyOfferData>()
                .HasMany(x => x.Images)
                .WithRequired()
                .HasForeignKey(x => x.PropertyOfferId)
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
                        .HasKey(x => new { x.PropertyOfferId, x.FileId });

            modelBuilder.Entity<PropertyPhoto>()
                        .HasRequired(x => x.File)
                        .WithMany()
                        .HasForeignKey(x => x.FileId)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<PropertyDocument>()
                        .HasKey(x => new { x.PropertyOfferId, x.FileId });

            modelBuilder.Entity<PropertyDocument>()
                .HasRequired(x => x.File)
                .WithMany()
                .HasForeignKey(x => x.FileId)
                .WillCascadeOnDelete(true);
        }
    }
}