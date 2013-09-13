namespace nahamaleo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyModels", "image", c => c.String());
            DropColumn("dbo.PropertyModels", "ImageData");
            DropColumn("dbo.PropertyModels", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyModels", "ImageMimeType", c => c.String());
            AddColumn("dbo.PropertyModels", "ImageData", c => c.Binary());
            DropColumn("dbo.PropertyModels", "image");
        }
    }
}
