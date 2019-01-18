namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpadteDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Post = c.String(maxLength: 50),
                        TradePlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TradePlaces", t => t.TradePlaceId, cascadeDelete: true)
                .Index(t => t.TradePlaceId);
            
            CreateTable(
                "dbo.TradePlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Age = c.Int(),
                        RoleId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId_Id, cascadeDelete: true)
                .Index(t => t.RoleId_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId_Id", "dbo.Roles");
            DropForeignKey("dbo.Employees", "TradePlaceId", "dbo.TradePlaces");
            DropIndex("dbo.Users", new[] { "RoleId_Id" });
            DropIndex("dbo.Employees", new[] { "TradePlaceId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.TradePlaces");
            DropTable("dbo.Employees");
        }
    }
}
