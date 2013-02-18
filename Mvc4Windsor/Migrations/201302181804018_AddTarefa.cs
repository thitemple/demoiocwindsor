namespace Mvc4Windsor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTarefa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        TarefaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.TarefaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarefas");
            DropTable("dbo.UserProfile");
        }
    }
}
