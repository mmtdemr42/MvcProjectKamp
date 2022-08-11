namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Draft_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        DraftSubject = c.String(maxLength: 50),
                        DraftContent = c.String(),
                        DraftDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DraftID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
