using System.Web.ApplicationServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bookshop.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bookshop.Model.BookshopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Bookshop.Model.BookshopDbContext context)
        {
            AddCategory(context);
            AddDepartments(context);
            AddRoles(context);
            AddAdmin(context);
            AddCondition(context);

        }

        private void AddCondition(BookshopDbContext context)
        {
            context.Conditions.AddOrUpdate(
                p=> p.Name,
                new Condition() {Name = "Old"},
                new Condition() { Name = "Overall" },
                new Condition() { Name = "New" });
        }

        private void AddCategory(BookshopDbContext context)
        {
            context.Categories.AddOrUpdate(
              p => p.Name,
              new Category() { Name = "Mathematics" },
              new Category() { Name = "Physics" },
              new Category() { Name = "English" }
            );
            context.SaveChanges();
        }

        private void AddDepartments(BookshopDbContext context)
        {
            context.Departments.AddOrUpdate(
              p => p.Name,
              new Department() { Name = "CSE" },
              new Department() { Name = "EEE" },
              new Department() { Name = "BBA" }
            );
            context.SaveChanges();
        }

        private void AddRoles(BookshopDbContext context)
        {
            string[] roles = { "Admin", "User" };
            foreach (string s in roles)
            {
                IdentityRole identityRole = context.Roles.FirstOrDefault(x => x.Name == s);
                if (identityRole == null)
                {
                    IdentityRole role = new IdentityRole() { Name = s };
                    context.Roles.Add(role);
                }
                context.SaveChanges();
            }
        }

        private void AddAdmin(BookshopDbContext context)
        {
            string guid = Guid.NewGuid().ToString();
            IdentityRole r = context.Roles.FirstOrDefault(x => x.Name == "Admin");
            if (r != null)
            {
                IdentityUserRole identityUserRole = new IdentityUserRole()
                {
                    RoleId = r.Id,
                    UserId = guid
                };
                string password = new PasswordHasher().HashPassword("Me.rahim29");
                var s = Guid.NewGuid().ToString("D");
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Id = guid,
                    Email = "rahim.prsf@hotmail.com",
                    PhoneNumber = "01673467667",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    Roles = { identityUserRole },
                    UidId = "011131148",
                    SecurityStamp = s,
                    UserName = "Md. Abdur Rahim"
                };
                context.Users.Add(applicationUser);
                context.SaveChanges();

            }
        }
    }
}
