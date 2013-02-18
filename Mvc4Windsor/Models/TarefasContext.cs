using System.Data.Entity;

namespace Mvc4Windsor.Models
{
    public class TarefasContext : DbContext
    {
        public TarefasContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}