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
                user = new ApplicationUser() { UserName = userName, Email = userName, DateOfBirth = null };

                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForAdmin = userManager.GetRoles(user.Id);
            if (!rolesForAdmin.Contains(roleName))
            {
                userManager.AddToRole(user.Id, roleName);
            }

            AddUserData(context);
        }

        private void AddRolesData(ApplicationDbContext context)
        {
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var roles = new List<ApplicationRole>();
            roles.Add(new ApplicationRole() { Name = "admin", Description = "Role for admin only", IsSytemRole = true });
            roles.Add(new ApplicationRole() { Name = "registered", Description = "Registed user", IsSytemRole = true });
            roles.Add(new ApplicationRole() { Name = "vendors", Description = "vendors", IsSytemRole = true });
            roles.Add(new ApplicationRole() { Name = "forum-moderators", Description = "Manage forum" });
            roles.Add(new ApplicationRole() { Name = "guests", Description = "Not authorised user", IsSytemRole = true });
            for (int i = 0; i < 20; i++)
            {
                var role = new ApplicationRole() { Name = "Role" + i, Description = "Description" + i, IsSytemRole = false };
                roles.Add(role);
            }

            foreach (var role in roles)
            {
                var existRole = roleManager.FindByName(role.Name);
                if (existRole == null)
                {
                    roleManager.Create(role);
                }
            }
        }

        private void AddUserData(ApplicationDbContext context)
        {
            Random rd = new Random();

            string[] roles = new string[] { "registered", "vendors", "forum-moderators", "guests" };
            string[] users = new string[] { "anna", "koala", "jira","mariaozawa", "ronaldo", "messi", "neymar", "ibra", "bale", "ozin",
                                            "benzema", "ramos", "navas", "isco", "kroos", "marcelo","pepe","modric","casemiro","silva",
                                            "suarez","turan","gomes","pique","iniesta","digne","stegen","rafinha","vidal","busquest",
                                            "pobgba","rooney","batistan","rashford","eric","martial","depay","mata","deGea","valencia",
                                            "davidLuiz","hazard","kante","costa","oscar","febregas","alonso","wiliam","johnterry","pedro"};
            string[] companies = new string[] { "Real Madrid", "Barcelona", "Manchester United", "Chealse", "Arsenal", "Bayern Munich" };
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
            const string password = "P@ssw0rd123";
            for (int i = 0; i < users.Length; i++)
            {
                string userName = users[i];
                string companyName = companies[rd.Next(0, companies.Length)];
                string email = string.Format("{0}@lte.com", users[i]);
                DateTime dob = new DateTime(1980, 1, 1).AddDays(rd.Next(0, 5000));
                var user = userManager.FindByEmail(email);
                if (user != null)
                    userManager.Delete(user);

                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = email,
                    DateOfBirth = dob,
                    FirstName = userName,
                    LastName = userName,
                    Company = companyName,
                    Gender = rd.Next(0, 2).ToString()
                };
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);

                string roleName = roles[rd.Next(0, roles.Length)];
                userManager.AddToRole(user.Id, roleName);
            }

            //userManager.AddToRole()
        }
    }
}
