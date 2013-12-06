namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicBankInformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "ConfirmationNumber", c => c.String());
            DropColumn("dbo.Bills", "ApplicationUserID");
            DropColumn("dbo.Services", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "ApplicationUserID", c => c.Int(nullable: false));
            DropColumn("dbo.Bills", "ConfirmationNumber");
        }
    }
}
