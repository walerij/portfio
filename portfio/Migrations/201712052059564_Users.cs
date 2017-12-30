namespace portfio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "User_Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "User_Name", c => c.String(nullable: false));
        }
    }
}
