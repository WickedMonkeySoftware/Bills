using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFront.Models
{
    public class Income
    {
        public int IncomeID { get; set; }

        public DateTime Start { get; set; }
        public TimeSpan NextEvent { get; set; }

        public int Amount { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual BankAccount BankAccount { get; set; }
    }

    public enum SavingGoalType {
        Percentage,
        Amount
    }

    public class SavingGoal
    {
        public int SavingGoalID { get; set; }
        public DateTime Created { get; set; }
        
        public virtual SavingGoal Parent { get; set; }
        public virtual ICollection<SavingGoal> Children { get; set; }

        public SavingGoalType GoalType { get; set; }
        public int Amount { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }

    public class BankBalance
    {
        public DateTime EndOfDay { get; set; }
        public int Balance { get; set; }

        public int BillOffset { get; set; }
        public int IncomeOffset { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class BankAccount
    {
        public string Title { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual ICollection<BankBalance> Balances { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class Bank
    {
        public string Title { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}