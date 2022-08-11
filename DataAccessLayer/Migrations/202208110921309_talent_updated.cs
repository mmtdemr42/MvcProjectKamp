namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talent_updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Talents", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Talents", "Description", c => c.String(maxLength: 50));
        }
    }
}
