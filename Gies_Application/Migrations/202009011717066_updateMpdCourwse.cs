namespace Gies_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMpdCourwse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseId");
        }
    }
}
