namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Username : DbMigration
    {
        public override void Up()
        {
            AddColumn("library.Users", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("library.Users", "Username");
        }
    }
}
