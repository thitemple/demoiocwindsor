using System.Collections.Generic;
using System.Data;

namespace Mvc4Windsor.Models.Repository
{
    public class TarefaEntityFrameworkRepository : ITarefaRepository
    {
        private readonly TarefasContext _db;

        public TarefaEntityFrameworkRepository(TarefasContext dbContext)
        {
            _db = dbContext;
        }

        public IEnumerable<Tarefa> All()
        {
            return _db.Tarefas;
        }

        public Tarefa Find(int id)
        {
            return _db.Tarefas.Find(id);
        }

        public Tarefa Add(Tarefa novaTarefa)
        {
            _db.Tarefas.Add(novaTarefa);
            _db.SaveChanges();
            return novaTarefa;
        }

        public void Update(Tarefa tarefa)
        {
            _db.Entry(tarefa).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(int id)
        {
            var tarefa = Find(id);
            _db.Tarefas.Remove(tarefa);
            _db.SaveChanges();
        }
    }
}