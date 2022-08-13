namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin_email_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminEmail", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminEmail");
        }
    }
}
