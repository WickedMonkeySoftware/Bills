namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicBills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        ApplicationUserID = c.Int(nullable: false),
                        PeriodStart = c.DateTime(nullable: false),
                        Period = c.Time(nullable: false, precision: 7),
                        DueOn = c.DateTime(nullable: false),
                        AmountDue = c.Int(nullable: false),
                        Paid = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.Int(nullable: false),
                        Title = c.String(),
                        lastUpdated = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bills", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bills", new[] { "ServiceID" });
            DropIndex("dbo.Services", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Bills", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Services");
            DropTable("dbo.Bills");
        }
    }
}
