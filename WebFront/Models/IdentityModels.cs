using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace WebFront.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Bank> Banks { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<BankBalance> BankBallances { get; set; }
        public virtual ICollection<SavingGoal> SavingGoals { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankBalance> BankBallances { get; set; }
        public DbSet<SavingGoal> SavingGoals { get; set; }
        public DbSet<Income> Incomes { get; set; }
    }
}