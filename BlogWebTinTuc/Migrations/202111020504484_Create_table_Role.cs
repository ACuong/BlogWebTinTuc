namespace BlogWebTinTuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table_Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Accounts", "RoleID", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
            DropTable("dbo.Roles");
        }
    }
}
