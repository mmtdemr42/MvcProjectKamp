namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
        }
    }
}
