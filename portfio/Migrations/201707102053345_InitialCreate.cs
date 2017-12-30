namespace portfio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Contact_id = c.Int(nullable: false, identity: true),
                        Contact_Param = c.String(nullable: false),
                        Contact_Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Contact_id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Photos_Id = c.Int(nullable: false, identity: true),
                        Works_Id = c.Int(nullable: false),
                        Photos_Link = c.String(nullable: false),
                        Photos_Info = c.String(),
                    })
                .PrimaryKey(t => t.Photos_Id)
                .ForeignKey("dbo.Works", t => t.Works_Id, cascadeDelete: true)
                .Index(t => t.Works_Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Works_Id = c.Int(nullable: false, identity: true),
                        Topics_Id = c.Int(nullable: false),
                        Works_Title = c.String(nullable: false),
                        Works_Info = c.String(nullable: false),
                        Works_Link = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Works_Id)
                .ForeignKey("dbo.Topics", t => t.Topics_Id, cascadeDelete: true)
                .Index(t => t.Topics_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Topic_Id = c.Int(nullable: false, identity: true),
                        Topic_Name = c.String(nullable: false),
                        Topic_Info = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Price_Id = c.Int(nullable: false, identity: true),
                        Price_Name = c.String(nullable: false),
                        Price_Unit = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Price_Id);
            
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        Social_Id = c.Int(nullable: false, identity: true),
                        Social_Name = c.String(nullable: false),
                        Social_Link = c.String(nullable: false),
                        Social_Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Social_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        User_Name = c.String(nullable: false),
                        User_Login = c.String(nullable: false),
                        User_Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Works_Id", "dbo.Works");
            DropForeignKey("dbo.Works", "Topics_Id", "dbo.Topics");
            DropIndex("dbo.Works", new[] { "Topics_Id" });
            DropIndex("dbo.Photos", new[] { "Works_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.SocialLinks");
            DropTable("dbo.Prices");
            DropTable("dbo.Topics");
            DropTable("dbo.Works");
            DropTable("dbo.Photos");
            DropTable("dbo.Contacts");
        }
    }
}
