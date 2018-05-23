namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsUserBlockedMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("library.Users", "isBlocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("library.Users", "isBlocked");
        }
    }
}
