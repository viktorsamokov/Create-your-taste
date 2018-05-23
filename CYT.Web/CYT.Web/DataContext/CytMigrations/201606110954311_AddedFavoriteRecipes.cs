namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFavoriteRecipes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("library.Recipes", "UserId", "library.Users");
            AddColumn("library.Recipes", "User_UserId", c => c.Int());
            AddColumn("library.Recipes", "User_UserId1", c => c.Int());
            CreateIndex("library.Recipes", "User_UserId");
            CreateIndex("library.Recipes", "User_UserId1");
            AddForeignKey("library.Recipes", "User_UserId", "library.Users", "UserId");
            AddForeignKey("library.Recipes", "User_UserId1", "library.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("library.Recipes", "User_UserId1", "library.Users");
            DropForeignKey("library.Recipes", "User_UserId", "library.Users");
            DropIndex("library.Recipes", new[] { "User_UserId1" });
            DropIndex("library.Recipes", new[] { "User_UserId" });
            DropColumn("library.Recipes", "User_UserId1");
            DropColumn("library.Recipes", "User_UserId");
            AddForeignKey("library.Recipes", "UserId", "library.Users", "UserId", cascadeDelete: true);
        }
    }
}
