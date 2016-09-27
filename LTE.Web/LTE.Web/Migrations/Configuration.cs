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
    using System.Collections.Generic;

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
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
            const string userName = "admin@lte.com";
            const string password = "P@ssw0rd123";
            const string roleName = "admin";

            AddRolesData(context);

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

        private void AddRolesData(ApplicationDbContext context)
        {
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var roles = new List<ApplicationRole>();
            roles.Add(new ApplicationRole() { Name = "admin", Description = "Role for admin only" });
            roles.Add(new ApplicationRole() { Name = "registered", Description = "Registed user" });
            roles.Add(new ApplicationRole() { Name = "vendors", Description = "vendors" });
            roles.Add(new ApplicationRole() { Name = "forum-moderators", Description = "Manage forum" });
            roles.Add(new ApplicationRole() { Name = "guests", Description = "Not authorised user" });

            foreach (var role in roles)
            {
                var existRole = roleManager.FindByName(role.Name);
                if (existRole == null)
                {
                    roleManager.Create(role);
                }
            }
        }
    }
}
