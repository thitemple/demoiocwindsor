using System.Collections.Generic;
using System.Linq;

namespace Mvc4Windsor.Models.Repository
{
    public class TarefaWebServiceRepository : ITarefaRepository
    {
        public TarefaWebServiceRepository(IDependencia dependencia)
        {
            _dependencia = dependencia;
        }

        public IEnumerable<Tarefa> All()
        {
            return Tarefas;
        }

        public Tarefa Find(int id)
        {
            return Tarefas.FirstOrDefault(t => t.TarefaId == id);
        }

        public Tarefa Add(Tarefa novaTarefa)
        {
            novaTarefa.TarefaId = 1;
            if (Tarefas.Any())
                novaTarefa.TarefaId = Tarefas.Max(t => t.TarefaId) + 1;
            Tarefas.Add(novaTarefa);
            return novaTarefa;
        }

        public void Update(Tarefa tarefa)
        {
            var tarefaIndex = Tarefas.FindIndex(t => t.TarefaId == tarefa.TarefaId);
            Tarefas.RemoveAt(tarefaIndex);
            Tarefas.Insert(tarefaIndex, tarefa);
        }

        public void Remove(int id)
        {
            var tarefaToUpdate = Tarefas.Find(t => t.TarefaId == id);
            Tarefas.Remove(tarefaToUpdate);
        }

        private static readonly List<Tarefa> Tarefas = new List<Tarefa>{ new Tarefa
                    {
                        Descricao = "WS Comprar leite"
                    },
                new Tarefa
                    {
                        Descricao = "WS Jogar na MegaSena"
                    }};
        private readonly IDependencia _dependencia;
    }

    public interface IDependencia
    {
    }

    public class Dependencia : IDependencia
    {

    }
}