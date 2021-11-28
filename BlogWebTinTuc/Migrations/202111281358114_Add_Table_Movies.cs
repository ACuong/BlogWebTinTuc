namespace BlogWebTinTuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_Movies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MoviesID = c.String(nullable: false, maxLength: 128),
                        MoviesName = c.String(),
                    })
                .PrimaryKey(t => t.MoviesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
