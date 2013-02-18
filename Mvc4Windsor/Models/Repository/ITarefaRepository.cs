using System.Collections.Generic;

namespace Mvc4Windsor.Models.Repository
{
    public interface ITarefaRepository
    {
        IEnumerable<Tarefa> All();
        Tarefa Find(int id);
        Tarefa Add(Tarefa novaTarefa);
        void Update(Tarefa tarefa);
        void Remove(int id);
    }
}