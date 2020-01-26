namespace Memcomb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignUps",
                c => new
                    {
                    /*ID = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    ReleaseDate = c.DateTime(nullable: false),
                    Genre = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),*/
                    ID = c.Int(nullable: false, identity: true),
                    Username = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                    Phone_Number = c.String(),
                })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SignUps");
        }
    }
}
