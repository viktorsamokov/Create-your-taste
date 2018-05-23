namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveQuantityIngrediantEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("library.IngredientQuantities", "IngredientId", "library.Ingredients");
            DropIndex("library.IngredientQuantities", new[] { "IngredientId" });
            DropIndex("library.IngredientQuantities", new[] { "RecipeId" });
            AddColumn("library.Ingredients", "Quantity", c => c.String());
            AddColumn("library.Ingredients", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("library.Ingredients", "RecipeId");
            DropColumn("library.Ingredients", "IngredientType");
            DropTable("library.IngredientQuantities");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.IngredientQuantityId);
            
            AddColumn("library.Ingredients", "IngredientType", c => c.String());
            DropIndex("library.Ingredients", new[] { "RecipeId" });
            DropColumn("library.Ingredients", "RecipeId");
            DropColumn("library.Ingredients", "Quantity");
            CreateIndex("library.IngredientQuantities", "RecipeId");
            CreateIndex("library.IngredientQuantities", "IngredientId");
            AddForeignKey("library.IngredientQuantities", "IngredientId", "library.Ingredients", "IngredientId", cascadeDelete: true);
        }
    }
}
