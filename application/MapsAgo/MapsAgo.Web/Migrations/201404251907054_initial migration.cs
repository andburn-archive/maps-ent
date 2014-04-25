namespace MapsAgo.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Excerpt = c.String(maxLength: 128),
                        Description = c.String(),
                        Source = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        LocationId = c.Int(nullable: false),
                        EventTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.EventTypeId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Alias = c.String(maxLength: 128),
                        Coordinates = c.Geography(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        Url = c.String(nullable: false),
                        Description = c.String(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.Media", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropIndex("dbo.Media", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.Media");
            DropTable("dbo.Locations");
            DropTable("dbo.Events");
        }
    }
}
