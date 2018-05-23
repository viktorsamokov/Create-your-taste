using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CYT.Web.DataContext.IdentityMigrations
{

    using CYT.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\IdentityMigrations";
        }

        protected override void Seed(IdentityDb context)
        {
            context.Users.AddOrUpdate(
                 u => u.Email,
                 new ApplicationUser
                 {
                     Id = "5d35a220-4e83-47b9-a36f-800c752d894d",
                     Email = "viktor@gmail.com",
                     UserName = "Viktor",
                     PasswordHash = "AD7uC5asg37SI9Zxhd3imkPJMc1+L/78i1evtMi0dsfzXjAzET2bmwW+OC3HqouTMA==",
                     SecurityStamp = "dc707bd0-7e6a-403d-a03f-ff2475672227",
                     EmailConfirmed = true,
                 },
                 new ApplicationUser
                 {
                     Id = "0c8b19af-4d2e-4b68-ba28-57515532bd44",
                     Email = "martin@gmail.com",
                     UserName = "Martin",
                     PasswordHash = "AD7uC5asg37SI9Zxhd3imkPJMc1+L/78i1evtMi0dsfzXjAzET2bmwW+OC3HqouTMA==",
                     SecurityStamp = "8bec98f5-1362-42f2-bc91-2379065f2e19",
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "5d35a220-4e23-47b9-a36f-800c752d894d",
                     Email = "ivan.ginovski@yahoo.com",
                     UserName = "Ivan",
                     PasswordHash = "AD7uC5asg37SI9Zxhd3imkPJMc1+L/78i1evtMi0dsfzXjAzET2bmwW+OC3HqouTMA==",
                     SecurityStamp = "8bec98f5-1362-42f2-bc91-2379065f2e12",
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "b4d84ca8-7b9b-4a12-a951-c62bcfc15b44",
                     Email = "goran@gmail.com",
                     UserName = "Goran",
                     PasswordHash = "AD7uC5asg37SI9Zxhd3imkPJMc1+L/78i1evtMi0dsfzXjAzET2bmwW+OC3HqouTMA==",
                     SecurityStamp = "8bec98f5-1362-42f2-bc91-2379065f2e13",
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "b5d84ca8-7b9b-4a12-a951-c62bcfc15b44",
                     Email = "eli@gmail.com",
                     UserName = "Eli",
                     PasswordHash = "AD7uC5asg37SI9Zxhd3imkPJMc1+L/78i1evtMi0dsfzXjAzET2bmwW+OC3HqouTMA==",
                     SecurityStamp = "8bec98f5-1362-42f2-bc91-2379065f2e14",
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "b5d84ca8-7b2b-4a12-a931-c62aafc15b43",
                     Email = "admin@gmail.com",
                     UserName = "Admin",
                     PasswordHash = "AD7uC5asg37SI9Zxhd3imkPJMc1+L/78i1evtMi0dsfzXjAzET2bmwW+OC3HqouTMA==",
                     SecurityStamp = "8bec98f5-1362-42f2-bc91-2379065f2e15",
                     EmailConfirmed = true
                 }
            );

            context.SaveChanges();
        }
    }
}