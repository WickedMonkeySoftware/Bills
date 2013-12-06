namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removecreditaccounts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankAccounts", "Bank_BankID1", "dbo.Banks");
            DropIndex("dbo.BankAccounts", new[] { "Bank_BankID1" });
            DropColumn("dbo.BankAccounts", "Discriminator");
            DropColumn("dbo.BankAccounts", "Bank_BankID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankAccounts", "Bank_BankID1", c => c.Int());
            AddColumn("dbo.BankAccounts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.BankAccounts", "Bank_BankID1");
            AddForeignKey("dbo.BankAccounts", "Bank_BankID1", "dbo.Banks", "BankID");
        }
    }
}
