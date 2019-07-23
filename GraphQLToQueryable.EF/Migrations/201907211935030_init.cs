namespace GraphQLToQueryable.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RootEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Other_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OtherEntities", t => t.Other_Id)
                .Index(t => t.Other_Id);
            
            CreateTable(
                "dbo.OtherEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChildEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        OtherEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OtherEntities", t => t.OtherEntity_Id)
                .Index(t => t.OtherEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RootEntities", "Other_Id", "dbo.OtherEntities");
            DropForeignKey("dbo.ChildEntities", "OtherEntity_Id", "dbo.OtherEntities");
            DropIndex("dbo.ChildEntities", new[] { "OtherEntity_Id" });
            DropIndex("dbo.RootEntities", new[] { "Other_Id" });
            DropTable("dbo.ChildEntities");
            DropTable("dbo.OtherEntities");
            DropTable("dbo.RootEntities");
        }
    }
}
