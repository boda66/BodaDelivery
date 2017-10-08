namespace TelerikAcademy.ForumSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TelerikAcademy.ForumSystem.Data.Model;

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        private const string AdministratorUserName = "info@telerikacademy.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedUsers(context);
            this.SeedSampleData(context);

            base.Seed(context);
        }

        private void SeedUsers(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Employee";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);
                roleName = "User";
                role = new IdentityRole { Name = roleName };
                roleManager.Create(role);
                roleName = "Admin";
                role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedSampleData(MsSqlDbContext context)
        {
            if (!context.Posts.Any())
            {

                var post = new Meal()
                {
                    Title = "Chicken ",
                    Content = "Roasted chicken.",
                    //Author = context.Users.First(x => x.Email == AdministratorUserName),
                    Price = 3,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwTCOOdf96ZVZPbl8oKTL3VYWm2vc9Q_Zk2RQflxSXteCSuC43CA",
                    CreatedOn = DateTime.Now
                };

                context.Posts.Add(post);

            }
        }
    }
}
