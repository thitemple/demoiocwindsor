using Mvc4Windsor.Models;

namespace Mvc4Windsor.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Mvc4Windsor.Models.TarefasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mvc4Windsor.Models.TarefasContext context)
        {
            context.Tarefas.AddOrUpdate(
                new Tarefa
                    {
                        Descricao = "Comprar leite"
                    },
                new Tarefa
                    {
                        Descricao = "Jogar na MegaSena"
                    });
        }
    }
}
