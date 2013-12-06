namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingbankinginformationtouser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Bank_BankID = c.Int(),
                    })
                .PrimaryKey(t => t.BankAccountID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Banks", t => t.Bank_BankID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Bank_BankID);
            
            CreateTable(
                "dbo.BankBalances",
                c => new
                    {
                        BankBalanceID = c.Int(nullable: false, identity: true),
                        EndOfDay = c.DateTime(nullable: false),
                        Balance = c.Int(nullable: false),
                        BillOffset = c.Int(nullable: false),
                        IncomeOffset = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        BankAccount_BankAccountID = c.Int(),
                    })
                .PrimaryKey(t => t.BankBalanceID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_BankAccountID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.BankAccount_BankAccountID);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BankID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        IncomeID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        NextEvent = c.Time(nullable: false, precision: 7),
                        Amount = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        BankAccount_BankAccountID = c.Int(),
                    })
                .PrimaryKey(t => t.IncomeID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccount_BankAccountID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.BankAccount_BankAccountID);
            
            CreateTable(
                "dbo.SavingGoals",
                c => new
                    {
                        SavingGoalID = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        GoalType = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Parent_SavingGoalID = c.Int(),
                    })
                .PrimaryKey(t => t.SavingGoalID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.SavingGoals", t => t.Parent_SavingGoalID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Parent_SavingGoalID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavingGoals", "Parent_SavingGoalID", "dbo.SavingGoals");
            DropForeignKey("dbo.SavingGoals", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "BankAccount_BankAccountID", "dbo.BankAccounts");
            DropForeignKey("dbo.Incomes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BankAccounts", "Bank_BankID", "dbo.Banks");
            DropForeignKey("dbo.Banks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BankBalances", "BankAccount_BankAccountID", "dbo.BankAccounts");
            DropForeignKey("dbo.BankBalances", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BankAccounts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SavingGoals", new[] { "Parent_SavingGoalID" });
            DropIndex("dbo.SavingGoals", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Incomes", new[] { "BankAccount_BankAccountID" });
            DropIndex("dbo.Incomes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BankAccounts", new[] { "Bank_BankID" });
            DropIndex("dbo.Banks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BankBalances", new[] { "BankAccount_BankAccountID" });
            DropIndex("dbo.BankBalances", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BankAccounts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.SavingGoals");
            DropTable("dbo.Incomes");
            DropTable("dbo.Banks");
            DropTable("dbo.BankBalances");
            DropTable("dbo.BankAccounts");
        }
    }
}
