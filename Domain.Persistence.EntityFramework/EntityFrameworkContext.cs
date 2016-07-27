﻿using System.Data.Entity;
using Domain.Persistence.EntityFramework.Conventions;
using Domain.Entities.Implementation;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.File;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Persistence.EntityFramework.Migrations;

namespace Domain.Persistence.EntityFramework
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext() : base("Default") { }
            
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EntityFrameworkContext, Configuration>());

            modelBuilder.Conventions.Add(new DateTime2Convention());

            modelBuilder.Entity<City>()
                        .HasKey(x => x.Id);
        }
    }
}