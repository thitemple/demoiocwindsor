using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mvc4Windsor.Controllers;
using Mvc4Windsor.Models;
using Mvc4Windsor.Models.Repository;

namespace Mvc4Windsor.Testes
{
    [TestClass]
    public class TarefaControllerTestes
    {
        [TestMethod]
        public void Index_deve_listar_todos_as_tarefas()
        {
            var tarefaFakeRepository = new Mock<ITarefaRepository>();
            var tarefas = new List<Tarefa>
                {
                    new Tarefa {TarefaId = 1, Descricao = "Tarefa 1"}, new Tarefa {TarefaId = 2, Descricao = "Tarefa 3"}
                };
            tarefaFakeRepository.Setup(t => t.All()).Returns(tarefas);

            var tarefaController = new TarefaController(tarefaFakeRepository.Object);
            var viewResult = tarefaController.Index() as ViewResult;
            var model = viewResult.Model as IEnumerable<Tarefa>;
            
            
            Assert.AreEqual(2, model.Count());
            Assert.AreEqual("Tarefa 1", model.First().Descricao);
        }
    }
}
