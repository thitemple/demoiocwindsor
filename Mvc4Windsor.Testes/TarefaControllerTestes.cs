using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc4Windsor.Controllers;
using Mvc4Windsor.Models;

namespace Mvc4Windsor.Testes
{
    [TestClass]
    public class TarefaControllerTestes
    {
        [TestMethod]
        public void Index_deve_listar_todos_as_tarefas()
        {
            var tarefaController = new TarefaController();
            var viewResult = tarefaController.Index() as ViewResult;
            var model = viewResult.Model as IEnumerable<Tarefa>;
            
            
            //Assert.AreEqual(model.Count);
        }
    }
}
