namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexpenses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankBalances", "BankAccount_BankAccountID", "dbo.BankAccounts");
            DropIndex("dbo.BankBalances", new[] { "BankAccount_BankAccountID" });
            RenameColumn(table: "dbo.BankBalances", name: "BankAccount_BankAccountID", newName: "BankAccountID");
            AlterColumn("dbo.BankBalances", "BankAccountID", c => c.Int(nullable: false));
            CreateIndex("dbo.BankBalances", "BankAccountID");
            AddForeignKey("dbo.BankBalances", "BankAccountID", "dbo.BankAccounts", "BankAccountID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankBalances", "BankAccountID", "dbo.BankAccounts");
            DropIndex("dbo.BankBalances", new[] { "BankAccountID" });
            AlterColumn("dbo.BankBalances", "BankAccountID", c => c.Int());
            RenameColumn(table: "dbo.BankBalances", name: "BankAccountID", newName: "BankAccount_BankAccountID");
            CreateIndex("dbo.BankBalances", "BankAccount_BankAccountID");
            AddForeignKey("dbo.BankBalances", "BankAccount_BankAccountID", "dbo.BankAccounts", "BankAccountID");
        }
    }
}
