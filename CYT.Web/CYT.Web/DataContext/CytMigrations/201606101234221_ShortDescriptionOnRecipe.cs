namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescriptionOnRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("library.Recipes", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("library.Recipes", "ShortDescription");
        }
    }
}
