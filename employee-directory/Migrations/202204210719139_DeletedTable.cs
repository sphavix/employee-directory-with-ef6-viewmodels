namespace employee_directory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.DepartmentViewModels");
            DropTable("dbo.DepartmentViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DepartmentViewModels",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            AddForeignKey("dbo.Employees", "DepartmentID", "dbo.DepartmentViewModels", "DepartmentID", cascadeDelete: true);
        }
    }
}
