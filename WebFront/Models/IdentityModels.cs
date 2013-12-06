using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}