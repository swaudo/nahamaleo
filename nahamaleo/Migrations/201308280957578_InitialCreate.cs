namespace nahamaleo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        property_location = c.String(),
                        property_type = c.String(),
                        no_of_rooms = c.String(),
                        rent_or_buy = c.String(),
                        property_cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PropertyModels");
        }
    }
}
