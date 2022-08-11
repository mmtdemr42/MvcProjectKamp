namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talent_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Surname = c.String(maxLength: 20),
                        ImagePath = c.String(maxLength: 250),
                        Description = c.String(maxLength: 50),
                        TalentName_1 = c.String(maxLength: 20),
                        TalentLevel_1 = c.Int(nullable: false),
                        TalentName_2 = c.String(maxLength: 20),
                        TalentLevel_2 = c.Int(nullable: false),
                        TalentName_3 = c.String(maxLength: 20),
                        TalentLevel_3 = c.Int(nullable: false),
                        TalentName_4 = c.String(maxLength: 20),
                        TalentLevel_4 = c.Int(nullable: false),
                        TalentName_5 = c.String(maxLength: 20),
                        TalentLevel_5 = c.Int(nullable: false),
                        TalentName_6 = c.String(maxLength: 20),
                        TalentLevel_6 = c.Int(nullable: false),
                        TalentName_7 = c.String(maxLength: 20),
                        TalentLevel_7 = c.Int(nullable: false),
                        TalentName_8 = c.String(maxLength: 20),
                        TalentLevel_8 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TalentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talents");
        }
    }
}
