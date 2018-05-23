using CYT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CYT.Web.DataContext
{
    public class CytDb : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<RecipeVote> RecipeVotes { get; set; }
        public DbSet<User> Users { get; set; }

        public CytDb() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("library");

            base.OnModelCreating(modelBuilder);
        }
    }
}