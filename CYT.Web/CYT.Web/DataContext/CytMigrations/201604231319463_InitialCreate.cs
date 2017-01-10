namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "library.IngredientQuantities",
                c => new
                    {
                        IngredientQuantityId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientQuantityId)
                .ForeignKey("library.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("library.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "library.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IngredientType = c.String(),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "library.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        GlutenFree = c.Boolean(nullable: false),
                        PreparationTime = c.Int(nullable: false),
                        VideoUrl = c.String(),
                        TimeCreated = c.DateTime(nullable: false),
                        Rating = c.Single(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        RecipeStatus = c.Int(nullable: false),
                        RecipeCategoryId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("library.RecipeCategories", t => t.RecipeCategoryId, cascadeDelete: true)
                .ForeignKey("library.Users", t => t.User_UserId)
                .Index(t => t.RecipeCategoryId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "library.RecipeCategories",
                c => new
                    {
                        RecipeCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RecipeCategoryId);
            
            CreateTable(
                "library.RecipeImages",
                c => new
                    {
                        RecipeImageId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TimeCreated = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeImageId)
                .ForeignKey("library.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "library.RecipeVotes",
                c => new
                    {
                        RecipeVoteId = c.Int(nullable: false, identity: true),
                        VoteValue = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeVoteId)
                .ForeignKey("library.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("library.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "library.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ProfileImage = c.String(),
                        Rating = c.Single(nullable: false),
                        UserRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("library.IngredientQuantities", "RecipeId", "library.Recipes");
            DropForeignKey("library.RecipeVotes", "UserId", "library.Users");
            DropForeignKey("library.Recipes", "User_UserId", "library.Users");
            DropForeignKey("library.RecipeVotes", "RecipeId", "library.Recipes");
            DropForeignKey("library.RecipeImages", "RecipeId", "library.Recipes");
            DropForeignKey("library.Recipes", "RecipeCategoryId", "library.RecipeCategories");
            DropForeignKey("library.IngredientQuantities", "IngredientId", "library.Ingredients");
            DropIndex("library.RecipeVotes", new[] { "RecipeId" });
            DropIndex("library.RecipeVotes", new[] { "UserId" });
            DropIndex("library.RecipeImages", new[] { "RecipeId" });
            DropIndex("library.Recipes", new[] { "User_UserId" });
            DropIndex("library.Recipes", new[] { "RecipeCategoryId" });
            DropIndex("library.IngredientQuantities", new[] { "RecipeId" });
            DropIndex("library.IngredientQuantities", new[] { "IngredientId" });
            DropTable("library.Users");
            DropTable("library.RecipeVotes");
            DropTable("library.RecipeImages");
            DropTable("library.RecipeCategories");
            DropTable("library.Recipes");
            DropTable("library.Ingredients");
            DropTable("library.IngredientQuantities");
        }
    }
}
