namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcreditaccounts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "CreditLimit", c => c.Int());
            AddColumn("dbo.BankAccounts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.BankAccounts", "Bank_BankID1", c => c.Int());
            CreateIndex("dbo.BankAccounts", "Bank_BankID1");
            AddForeignKey("dbo.BankAccounts", "Bank_BankID1", "dbo.Banks", "BankID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "Bank_BankID1", "dbo.Banks");
            DropIndex("dbo.BankAccounts", new[] { "Bank_BankID1" });
            DropColumn("dbo.BankAccounts", "Bank_BankID1");
            DropColumn("dbo.BankAccounts", "Discriminator");
            DropColumn("dbo.BankAccounts", "CreditLimit");
        }
    }
}
