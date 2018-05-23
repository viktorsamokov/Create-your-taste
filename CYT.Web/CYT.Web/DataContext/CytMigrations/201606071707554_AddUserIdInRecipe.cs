namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdInRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("library.Recipes", "User_UserId", "library.Users");
            DropIndex("library.Recipes", new[] { "User_UserId" });
            RenameColumn(table: "library.Recipes", name: "User_UserId", newName: "UserId");
            AlterColumn("library.Recipes", "UserId", c => c.Int(nullable: false));
            CreateIndex("library.Recipes", "UserId");
            AddForeignKey("library.Recipes", "UserId", "library.Users", "UserId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("library.Recipes", "UserId", "library.Users");
            DropIndex("library.Recipes", new[] { "UserId" });
            AlterColumn("library.Recipes", "UserId", c => c.Int());
            RenameColumn(table: "library.Recipes", name: "UserId", newName: "User_UserId");
            CreateIndex("library.Recipes", "User_UserId");
            AddForeignKey("library.Recipes", "User_UserId", "library.Users", "UserId");
        }
    }
}
