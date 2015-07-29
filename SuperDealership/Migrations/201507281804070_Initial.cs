namespace SuperDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        MPGLow = c.Int(nullable: false),
                        MPGHigh = c.Int(nullable: false),
                        Color = c.String(),
                        MSRP = c.Double(nullable: false),
                        Mileage = c.Double(nullable: false),
                        CarImg = c.String(),
                        VIN = c.Int(nullable: false),
                        IsOwned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Autoes");
            DropTable("dbo.Users");
        }
    }
}
