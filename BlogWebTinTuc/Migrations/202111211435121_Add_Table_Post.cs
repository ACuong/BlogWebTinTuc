namespace BlogWebTinTuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_Post : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Url_image = c.String(),
                        Textbody = c.String(),
                        CategoryID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID); 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropTable("dbo.Posts");
        }
    }
}
