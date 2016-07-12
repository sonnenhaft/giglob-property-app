namespace Domain.Persistence.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_File_District_MetroStation_MetroBranch_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CityId = c.Long(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.MetroBranches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CityId = c.Long(nullable: false),
                        HexColor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.MetroStations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CityId = c.Long(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Extension = c.String(),
                        MimeType = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MetroStationToMetroBranchRelations",
                c => new
                    {
                        StationId = c.Long(nullable: false),
                        BranchId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.StationId, t.BranchId })
                .ForeignKey("dbo.MetroStations", t => t.StationId, cascadeDelete: true)
                .ForeignKey("dbo.MetroBranches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.StationId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetroStations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.MetroStationToMetroBranchRelations", "BranchId", "dbo.MetroBranches");
            DropForeignKey("dbo.MetroStationToMetroBranchRelations", "StationId", "dbo.MetroStations");
            DropForeignKey("dbo.MetroBranches", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.MetroStationToMetroBranchRelations", new[] { "BranchId" });
            DropIndex("dbo.MetroStationToMetroBranchRelations", new[] { "StationId" });
            DropIndex("dbo.MetroStations", new[] { "CityId" });
            DropIndex("dbo.MetroBranches", new[] { "CityId" });
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropTable("dbo.MetroStationToMetroBranchRelations");
            DropTable("dbo.Files");
            DropTable("dbo.MetroStations");
            DropTable("dbo.MetroBranches");
            DropTable("dbo.Districts");
        }
    }
}
