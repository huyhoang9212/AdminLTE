namespace LTE.Web.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity;
    internal sealed class Configuration : DbMigrationsConfiguration<LTE.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LTE.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

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

            //ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context);
            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
            const string userName = "admin@example.com";
            const string password = "P@ssw0rd123";
            const string roleName = "admin";

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                role.Description = "Role for admin only";
                roleManager.Create(role);
            }

            var user = userManager.FindByEmail(userName);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = userName, Email = userName };
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForAdmin = userManager.GetRoles(user.Id);
            if (!rolesForAdmin.Contains(roleName))
            {
                userManager.AddToRole(user.Id, roleName);
            }
        }
    }
}
