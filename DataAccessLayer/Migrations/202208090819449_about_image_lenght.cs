namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class about_image_lenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 250));
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 100));
        }
    }
}
