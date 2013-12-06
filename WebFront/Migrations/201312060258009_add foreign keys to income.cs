namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforeignkeystoincome : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Incomes", "BankAccount_BankAccountID", "dbo.BankAccounts");
            DropIndex("dbo.Incomes", new[] { "BankAccount_BankAccountID" });
            RenameColumn(table: "dbo.Incomes", name: "ApplicationUser_Id", newName: "ApplicationUserID");
            RenameColumn(table: "dbo.Incomes", name: "BankAccount_BankAccountID", newName: "BankAccountID");
            AlterColumn("dbo.Incomes", "BankAccountID", c => c.Int(nullable: false));
            CreateIndex("dbo.Incomes", "BankAccountID");
            AddForeignKey("dbo.Incomes", "BankAccountID", "dbo.BankAccounts", "BankAccountID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "BankAccountID", "dbo.BankAccounts");
            DropIndex("dbo.Incomes", new[] { "BankAccountID" });
            AlterColumn("dbo.Incomes", "BankAccountID", c => c.Int());
            RenameColumn(table: "dbo.Incomes", name: "BankAccountID", newName: "BankAccount_BankAccountID");
            RenameColumn(table: "dbo.Incomes", name: "ApplicationUserID", newName: "ApplicationUser_Id");
            CreateIndex("dbo.Incomes", "BankAccount_BankAccountID");
            AddForeignKey("dbo.Incomes", "BankAccount_BankAccountID", "dbo.BankAccounts", "BankAccountID");
        }
    }
}
