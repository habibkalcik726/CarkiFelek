namespace CarkiFelek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gift",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GiftName = c.String(),
                        Possibility = c.Int(nullable: false),
                        CanGetPoint = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Point",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PointScore = c.Int(nullable: false),
                        Possibility = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Point");
            DropTable("dbo.Gift");
        }
    }
}
