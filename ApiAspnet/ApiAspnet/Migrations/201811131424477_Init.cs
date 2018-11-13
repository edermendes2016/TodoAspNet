namespace ApiAspnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoItem");
        }
    }
}
