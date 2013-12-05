namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFront.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebFront.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            AddUserRole(context);

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

        bool AddUserRole(WebFront.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));

            var um = new UserManager<WebFront.Models.ApplicationUser>(new UserStore<WebFront.Models.ApplicationUser>(context));
            var user = new WebFront.Models.ApplicationUser() { UserName = "withinboredom" };

            ir = um.Create(user, "Sh@dow9637");

            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }

            ir = um.AddToRole(user.Id, "canEdit");

            return ir.Succeeded;
        }

        #endregion
    }
}
