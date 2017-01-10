namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CYT.Web.DataContext.CytDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\CytMigrations";
        }

        protected override void Seed(CYT.Web.DataContext.CytDb context)
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
           
            context.SaveChanges();
        }
    }
}
