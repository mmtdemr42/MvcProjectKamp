namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFile_up : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ImageFıle", newName: "ImageFiles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ImageFiles", newName: "ImageFıle");
        }
    }
}
