namespace C_FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Director = c.String(),
                        Star1 = c.String(),
                        Star2 = c.String(),
                        Year = c.Int(nullable: false),
                        Promo = c.Binary(),
                        StudioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmID)
                .ForeignKey("dbo.Studios", t => t.StudioID, cascadeDelete: true)
                .Index(t => t.StudioID);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        StudioID = c.Int(nullable: false, identity: true),
                        SName = c.String(),
                    })
                .PrimaryKey(t => t.StudioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "StudioID", "dbo.Studios");
            DropIndex("dbo.Films", new[] { "StudioID" });
            DropTable("dbo.Studios");
            DropTable("dbo.Films");
        }
    }
}
