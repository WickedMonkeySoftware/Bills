namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WebFront.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFront.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebFront.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var user = AddUserRole(context);

            var bank = new Bank { ApplicationUser = user, Title = "USAA" };
            context.Banks.AddOrUpdate(bank);

            var account = new BankAccount { ApplicationUser = user, Bank = bank, Title = "All Accounts" };
            context.BankAccounts.AddOrUpdate(account);

            var creditcards = new Bank { ApplicationUser = user, Title = "Capital One" };
            context.Banks.AddOrUpdate(creditcards);

            var credit = new BankAccount { Title = "Business Card", ApplicationUser = user, Bank = creditcards, CreditLimit = 25000 };
            var personal = new BankAccount { ApplicationUser = user, Bank = creditcards, CreditLimit = 50000, Title = "Personal Card" };
            context.BankAccounts.AddOrUpdate(credit, personal);
            
            var incomes = new System.Collections.Generic.List<Income>
            {
                new Income { ApplicationUser = user, BankAccount = account, Start = new DateTime(2013, 11, 27), NextEvent = new DateTime(2013, 12, 13), Amount = 157731},
                new Income { ApplicationUser = user, BankAccount = account, Start = new DateTime(2013, 11, 26), NextEvent = new DateTime(2013, 12, 12), Amount = 99192},
                new Income { ApplicationUser = user, BankAccount = account, Start = new DateTime(2013, 12, 1), NextEvent = new DateTime(2014, 1, 1), Amount = 86400},
                new Income { ApplicationUser = user, BankAccount = account, Start = new DateTime(2013, 12, 1), NextEvent = new DateTime(2014, 1, 1), Amount = 129300},
            };

            incomes.ForEach(s => context.Incomes.AddOrUpdate(p => p.Amount, s));
            
            var expenses = new System.Collections.Generic.List<BankBalance>
            {
                new BankBalance { ApplicationUser = user, BankAccount = account, BillOffset = 0, EndOfDay = new DateTime(2013, 12, 2), IncomeOffset = 0, Balance = 224492},
                new BankBalance { ApplicationUser = user, BankAccount = account, BillOffset = 0, EndOfDay = new DateTime(2013, 12, 3), IncomeOffset = 0, Balance = 134108},
                new BankBalance { ApplicationUser = user, BankAccount = account, BillOffset = 0, EndOfDay = new DateTime(2013, 12, 4), IncomeOffset = 0, Balance = 73878},
                new BankBalance { ApplicationUser = user, BankAccount = account, BillOffset = 0, EndOfDay = new DateTime(2013, 12, 5), IncomeOffset = 0, Balance = 67082},
            };

            expenses.ForEach(s => context.BankBallances.AddOrUpdate(p => p.EndOfDay, s));
            
            context.SaveChanges();

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        #region Supporting Seed Methods

        ApplicationUser AddUserRole(WebFront.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));

            var um = new UserManager<WebFront.Models.ApplicationUser>(new UserStore<WebFront.Models.ApplicationUser>(context));
            var user = new WebFront.Models.ApplicationUser() { UserName = "withinboredom" };

            ir = um.Create(user, "Sh@dow9637");

            if (ir.Succeeded == false)
            {
                return um.FindByName("withinboredom");
            }

            ir = um.AddToRole(user.Id, "canEdit");

            return user;
        }

        #endregion
    }
}
