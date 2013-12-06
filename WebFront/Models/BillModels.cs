using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace WebFront.Models
{
    public class Service
    {
        public int ServiceID { get; set; }

        public string Title { get; set; }

        public DateTime lastUpdated { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }

    public enum PaymentStatus
    {
        NotPaid,
        Pending,
        Paid,
        Cancelled
    }

    public class Bill
    {
        public int BillID { get; set; }
        public int ServiceID { get; set; }
        public string ConfirmationNumber { get; set; }

        public DateTime PeriodStart { get; set; }

        public TimeSpan Period { get; set; }

        public DateTime DueOn { get; set; }

        public int AmountDue { get; set; }

        public PaymentStatus Paid { get; set; }

        public virtual Service Service { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}