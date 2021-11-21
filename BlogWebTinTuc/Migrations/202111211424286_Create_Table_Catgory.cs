namespace BlogWebTinTuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Catgory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 10),
                        CategoryName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
